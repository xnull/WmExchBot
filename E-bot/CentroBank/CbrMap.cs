using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using log4net;

namespace ru.xnull.CentroBank
{
    [XmlRoot("ValCurs")]
    public class CbrMap
    {
        private static ILog log = LogManager.GetLogger(typeof(CbrMap));

        private String _date;
        private List<CurrencyMap> _currencyList;

        [XmlAttribute("Date")]
        public String date
        {
            get { return _date; }
            set { _date = value; }
        }

        [XmlElement("Valute")]
        public List<CurrencyMap> currencyList
        {
            get { return _currencyList; }
            set { _currencyList = value; }
        }
               
        public CurrencyMap getCurrency(String charCode)
        {
            log.Debug("Получить валюту: " + charCode + " из курсов цб");
            foreach (CurrencyMap currentCurrency in _currencyList)
            {
                if (currentCurrency.CharCode.Equals(charCode))
                {
                    return currentCurrency;
                }
            }
            log.Warn("Валюта " + charCode + " не найдена в списке валют ЦБ");
            return null;
        }
    }
}
