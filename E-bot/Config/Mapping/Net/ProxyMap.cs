using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace ru.xnull.Config.Mapping.Net
{
    [XmlRoot("Proxy")]
    public class ProxyMap
    {        
        private String _ip;        
        private String _login;        
        private String _pass;
        private Boolean _useProxy;

        [XmlAttribute("ip")]
        public String ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        [XmlAttribute("login")]
        public String login
        {
            get { return _login; }
            set { _login = value; }
        }

        [XmlAttribute("pass")]
        public String pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        [XmlAttribute("useProxy")]
        public Boolean useProxy
        {
            get { return _useProxy; }
            set { _useProxy = value; }
        }
    }
}
