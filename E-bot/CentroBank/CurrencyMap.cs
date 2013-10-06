using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ru.xnull.CentroBank
{
    /// <summary>
    /// Валюта в хмл дкументе курсов валют цб
    /// </summary>
    [XmlRoot("Valute")]
    public class CurrencyMap
    {
        private String _id;
        private String _NumCode;
        private String _CharCode;
        private int _Nominal;
        private String _Name;
        private String _Value;


        [XmlAttribute("ID")]
        public String id
        {
            get { return _id; }
            set { _id = value; }
        }

        [XmlElement("NumCode")]
        public String NumCode
        {
            get { return _NumCode; }
            set { _NumCode = value; }
        }

        [XmlElement("CharCode")]
        public String CharCode
        {
            get { return _CharCode; }
            set { _CharCode = value; }
        }

        [XmlElement("Nominal")]
        public int Nominal
        {
            get { return _Nominal; }
            set { _Nominal = value; }
        }

        [XmlElement("Name")]
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Официальный курс валюты ЦБ
        /// </summary>
        [XmlElement("Value")]
        public String rate
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
}
