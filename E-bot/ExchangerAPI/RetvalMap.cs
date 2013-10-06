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
    [XmlRoot("retval")]
    public class RetvalMap
    {
        ///<?xml version="1.0"?> 
        ///<wm.exchanger.response> 
        ///<retval operid="1588091" wmtransid="198976006">0</retval> 
        ///<retdesc></retdesc> 
        ///</wm.exchanger.response>        
        private String _operid;
        private String _wmtransid;
        private int _status;

        [XmlAttribute("operid")]
        public String operid
        {
            get { return _operid; }
            set { _operid = value; }
        }

        [XmlAttribute("wmtransid")]
        public String wmtransid
        {
            get { return _wmtransid; }
            set { _wmtransid = value; }
        }

        [XmlText]
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        
    }
}
