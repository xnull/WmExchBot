using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ru.xnull.Exchanger.XmlMapping
{
    [XmlRoot("WMExchnagerQuerys")]
    public class ListBidsMap
    {
        private List<BidMap> _bids;

        [XmlElement("query")]
        public List<BidMap> bids
        {
            get { return _bids; }
            set { _bids = value; }
        }
    }
}
