using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
using System.Diagnostics;
using System.Xml.Serialization;

namespace ru.xnull.Config.Mapping
{
    [XmlRoot("wmids")]
    public class WmidsMap
    {
        private List<WmidMap> _wmids;

        [XmlElement("wmid")]
        public List<WmidMap> wmidList
        {
            get { return _wmids; }
            set { _wmids = value; }
        }

        public WmidMap getWmid(String wmidNumber)
        {
            foreach (WmidMap currWmid in _wmids)
            {
                if (currWmid.number == wmidNumber)
                {
                    return currWmid;
                }
            }
            return null;
        }

        public WmidMap getJobWmidMap()
        {
            return _wmids[0];
        }

        public WmidMap jobWmidMap
        {
            set { _wmids[0] = value; }
        }
    }
}
