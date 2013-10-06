using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ru.xnull.XmlInterfaces.Response
{
    [XmlRoot("w3s.response")]
    public class HistoryMap
    {
        private int _reqn;
        private String _retval;
        private String _retdesc;

        private OperationsMap _operations;

        [XmlElement("reqn")]        
        public int reqn
        {
            get { return _reqn; }
            set { _reqn = value; }
        }

        [XmlElement("retval")]        
        public String retval
        {
            get { return _retval; }
            set { _retval = value; }
        }

        [XmlElement("retdesc")]        
        public String retdesc
        {
            get { return _retdesc; }
            set { _retdesc = value; }
        }

        [XmlElement("operations")]
        public OperationsMap operations
        {
            get { return _operations; }
            set { _operations = value; }
        }

    }
}
