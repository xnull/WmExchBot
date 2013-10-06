using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.NetTools;
using System.Xml;

using log4net;
using ru.xnull.exchanger;

namespace ru.xnull.Exchanger
{
    /// <summary>
    /// Класс для получения заявок с сайта
    /// </summary>
    public class ListBidsDao : IListBidsDao
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ListBidsDao));

        private INetSender _netSender;
        private static String _url = "https://wm.exchanger.ru/asp/XMLWMList.asp";
        private CacheListBids _cache;

        public static String url
        {
            get { return _url; }
        }

        public ListBidsDao(INetSender netSender)
        {
            _netSender = netSender;
            _cache = new CacheListBids();
        }

        /// <summary>
        /// Получить список заявок с сайта по определенному направлению обмена
        /// </summary>
        /// <param name="exchType">Направление обмена</param>
        /// <returns></returns>       
        public ListBids getListBids(int exchType)
        {
            if (log.IsDebugEnabled)
            {
                ExchType exchTypeTools = new ExchType();
                log.Debug("Пытаемся получить список заявок с сайта, по направлению: " + exchTypeTools.GetDirectionFromExchType(exchType));
            }            

            if (_cache.containsListBids(exchType))
            {
                //проверяем время получения дока с сайта, если прошло меньше 30 секунд, то возращаем объект из кэша
                if (DateTime.Now < _cache.getDatePutInCache(exchType).AddSeconds(30))
                {
                    return (_cache.get(exchType));
                }                
            }
            //Получить данные с сайта и добавить их в кэш
            ListBids listBids = getListBidsFromSite(exchType);
            if (listBids != null)
            {
                _cache.put(listBids);
            }
            return listBids;
        }

        private ListBids getListBidsFromSite(int exchType)
        {
            try
            {
                XmlDocument xmlListBids = new XmlDocument();
                String result = getListBidsStringFromSite(exchType);
                xmlListBids.LoadXml(result);
                ListBids listBids = new ListBids(exchType, xmlListBids);
                log.Debug("Получили список обменов с сайта по направлению обмена: " + exchType);
                return listBids;
            }
            catch (Exception err)
            {
                log.Warn("Не удалось получить список заявок с биржи. Ошибка: " + err.Message);
                return null;
            }
        }

        private string getListBidsStringFromSite(int exchType)
        {
            String result = _netSender.sendGetData(_url + "?exchtype=" + exchType.ToString());
            if (result == null)
            {
                log.Warn("Ошибка посылки данных на сайт, последняя попытка посылки данных закончилась неудачно");
            }
            return result;
        }
    }
}
