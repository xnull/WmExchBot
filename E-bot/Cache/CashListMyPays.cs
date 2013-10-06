using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
using ru.xnull.NetTools;

using ru.xnull.XML;
using ru.xnull.MyPay;
using ru.xnull.Config.Mapping;
using log4net;
using ru.xnull.exchangerapi;

namespace ru.xnull.cache
{
    /// <summary>
    /// Кэш списка заявок с биржи
    /// </summary>
    public class CashListMyPays
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CashListMyPays));
        private List<MyPayMap> MyPays = new List<MyPayMap>();
        private INetSender _netSender;

        public CashListMyPays(INetSender netsender)
        {
            _netSender = netsender;
        }

        public MyPaysMap GetListMyPays(WmidMap wmid, string typeZayavka, String queryid)
        {
            log.Debug("Получить список моих заявок с биржи");
            MyPays.Clear();
            string postDataString = null;
            string url = "https://wm.exchanger.ru/asp/XMLWMList2.asp";
            string plainStr, query, signstr;
            plainStr = wmid.number + typeZayavka + queryid;
            signstr = ExchangerUtils.signString(wmid, plainStr);
            query = "<wm.exchanger.request>" +
                        "<wmid>" + wmid.number + "</wmid>" +
                        "<type>" + typeZayavka + "</type>" +
                        "<queryid>" + queryid + "</queryid>" +
                        "<signstr>" + signstr + "</signstr>" +
                    "</wm.exchanger.request>";
            try
            {
                postDataString = _netSender.sendPostData(url, query);
                XmlDocument myPaysDoc = new XmlDocument();
                myPaysDoc.LoadXml(postDataString);
                MyPaysMap myPaysMap = null;
                try
                {
                    XmlMapper mapper = new XmlMapper();
                    myPaysMap = mapper.xmlStringToClass<MyPaysMap>(myPaysDoc.DocumentElement["WMExchnagerQuerys"].OuterXml);
                }
                catch (Exception err)
                {
                    log.Error("Ошибка маппинга в классе CashListMyPays", err);
                }
                //MyPaysArray.Add(wmid + typeZayavka + queryid, MyPays);
                foreach (MyPayMap currentMyPayMap in myPaysMap.listMyPays)
                {
                    currentMyPayMap.wmid = wmid.number;
                }

                return myPaysMap;
            }
            catch (Exception err)
            {
                log.Error("Не смог получить данные. \n\nОтвет сервера:\n\n" + postDataString, err);
                return null;
            }
        }
    }
}
