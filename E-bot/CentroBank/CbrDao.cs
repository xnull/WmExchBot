using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.NetTools;
using System.Xml;
using ru.xnull.XML;
using log4net;

namespace ru.xnull.CentroBank
{
    /// <summary>
    /// Класс доступа к объекту CBR
    /// </summary>
    public class CbrDao : ICbrDao
    {
        private static ILog log = LogManager.GetLogger(typeof(CbrDao));

        private String _url = "http://www.cbr.ru/scripts/XML_daily.asp";

        private CbrMap cbr;
        private INetSender _netSender;
        private Boolean _updateRates = false;

        public Boolean updateRates
        {
            set { _updateRates = value; }
        }

        public CbrDao(INetSender netSender)
        {
            _netSender = netSender;
        }

        /// <summary>
        /// Получить из сети курсы ЦБ
        /// </summary>
        /// <returns></returns>
        public CbrMap getCbr(DateTime date)
        {
            XmlMapper mapper = new XmlMapper();
            if (cbr != null & !_updateRates)
            {
                log.Debug("Берем из кэша курсы ЦБ за " + date.ToString("yyyy-MM-dd"));                
            }
            if (_updateRates || cbr == null)
            {
                log.Debug("Получаем с сайта ЦБ курсы валют за " + date.ToString("yyyy-MM-dd"));
                cbr = mapper.xmlStringToClass<CbrMap>(_netSender.sendGetData(getResultUrl(date)));
            }
            _updateRates = false;
            return cbr;
        }

        /// <summary>
        /// Получить результирующий урл. Если запрашиваем курсы ЦБ за сегодняшний день, то урл должен быть без указания даты,
        /// чтобы не было ошибки в случае если на компе некорректная дата установлена.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public String getResultUrl(DateTime date)
        {
            String resultUrl = _url;
            if (date.ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                resultUrl += "?date_req=" + date.ToShortDateString();
            }
            return resultUrl;
        }
    }
}
