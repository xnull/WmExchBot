using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ru.xnull.XmlInterfaces.Response
{
    [XmlRoot("operations")]
    public class OperationsMap
    {
        private int _cnt;
        private List<OperationMap> _operationsList;

        [XmlAttribute("cnt")]
        public int cnt
        {
            get { return _cnt; }
            set { _cnt = value; }
        }

        [XmlElement("operation")]
        public List<OperationMap> operationsList
        {
            get { return _operationsList; }
            set { _operationsList = value; }
        }
    }
}
