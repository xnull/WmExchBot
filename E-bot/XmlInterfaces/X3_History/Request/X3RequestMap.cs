using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ru.xnull.XmlInterfaces.Request
{
    [XmlRoot("w3s.request")]
    public class X3RequestMap
    {
        private int _reqn;
        private String _wmid;
        private String _sign;
        private GetOperationsRequestMap _getOperations;

        [XmlElement("reqn")]        
        public int reqn
        {
            get { return _reqn; }
            set { _reqn = value; }
        }

        [XmlElement("wmid")]        
        public String wmid
        {
            get { return _wmid; }
            set { _wmid = value; }
        }

        [XmlElement("sign")]        
        public String sign
        {
            get { return _sign; }
            set { _sign = value; }
        }

        [XmlElement("getoperations")]
        public GetOperationsRequestMap getOperations
        {
            get { return _getOperations; }
            set { _getOperations = value; }
        }
    }
}
