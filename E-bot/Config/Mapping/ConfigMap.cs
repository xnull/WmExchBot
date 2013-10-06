using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.Config.Mapping.Bot;

namespace ru.xnull.Config.Mapping
{
    /// <summary>
    /// Смапленный класс конфига
    /// </summary>
    [XmlRoot("root")]
    public class ConfigMap
    {
        private WmidsMap _wmids;
        private NetMap _netMap;
        private BotMap _botMap;
        private List<BehaviorMap> _archiveMap;
        
        [XmlElement]
        public WmidsMap wmids
        {
            get { return _wmids; }
            set { _wmids = value; }
        }

        [XmlElement("Net")]
        public NetMap netMap
        {
            get { return _netMap; }
            set { _netMap = value; }
        }

        [XmlElement("Bot")]
        public BotMap botMap
        {
            get { return _botMap; }
            set { _botMap = value; }
        }
                
        [XmlArray("Archive")]
        [XmlArrayItem("Behavior")]
        public List<BehaviorMap> archiveMap
        {
            get { return _archiveMap; }
            set { _archiveMap = value; }
        }
    }
}
