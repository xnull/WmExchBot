using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ru.xnull.Config.Mapping.Net
{
    //[Serializable]
    [XmlRoot("Net")]
    public class NetMap
    {
        private int _tryConnect;
        private ProxyMap _proxyMap;
        private EmailMap _emailMap;

        /// <summary>
        /// Количество попыток соединения с сервером
        /// </summary>
        [XmlAttribute("tryConnect")]
        public int tryConnect
        {
            get { return _tryConnect; }
            set { _tryConnect = value; }
        }

        [XmlElement("Proxy")]
        public ProxyMap proxyMap
        {
            get { return _proxyMap; }
            set { _proxyMap = value; }
        }

        [XmlElement("Email")]
        public EmailMap emailMap
        {
            get { return _emailMap; }
            set { _emailMap = value; }
        }
    }
}
