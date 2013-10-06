using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ru.xnull.ExchangerAPI
{
    /// <summary>
    /// Класс ответа от эксченджера
    /// </summary>
    [XmlRoot("wm.exchanger.response")]
    public class ResponseMap
    {
        public const int SUCCESS = 0;
        /// <summary>
        /// Конструктор класса ответа сервера, на запрос клиента.
        /// </summary>
        /// <param name="xmlResponse">хмл документ присланный сервером в ответ на запрос</param>
        /// ответ сервера примерно такой 
        ///<?xml version="1.0"?> 
        ///<wm.exchanger.response> 
        ///<retval operid="1588091" wmtransid="198976006">0</retval> 
        ///<retdesc></retdesc> 
        ///</wm.exchanger.response>        
        private String _retdesc;
        private RetvalMap _retval;

        [XmlElement("retval")]
        public RetvalMap retval
        {
            get { return _retval; }
            set { _retval = value; }
        }

        [XmlElement("retdesc")]
        [XmlText]
        public String retdesc
        {
            get { return _retdesc; }
            set { _retdesc = value; }
        }

        
    }
}
