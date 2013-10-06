using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ru.xnull.XmlInterfaces.Request
{
    [XmlRoot("getoperations")]
    public class GetOperationsRequestMap
    {
        private String _purse;
        private String _datestart;
        private String _datefinish;

        [XmlElement("purse")]        
        public String purse
        {
            get { return _purse; }
            set { _purse = value; }
        }

        [XmlElement("datestart")]       
        public String datestart
        {
            get { return _datestart; }
            set { _datestart = value; }
        }

        [XmlElement("datefinish")]       
        public String datefinish
        {
            get { return _datefinish; }
            set { _datefinish = value; }
        }

    }
}
