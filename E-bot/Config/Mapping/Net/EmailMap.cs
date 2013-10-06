using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ru.xnull.Config.Mapping.Net
{
    //[Serializable]
    [XmlRoot("Email")]
    public class EmailMap
    {
        private String _server;
        private int _port;
        private String _login;
        private String _pass;
        private String _from;
        private String _to;
        private bool _usessl;
        private bool _sendmail;

        [XmlAttribute("server")]
        public String server
        {
            get { return _server; }
            set { _server = value; }
        }

        [XmlAttribute("port")]
        public int port
        {
            get { return _port; }
            set { _port = value; }
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

        [XmlAttribute("from")]
        public String from
        {
            get { return _from; }
            set { _from = value; }
        }

        [XmlAttribute("to")]
        public String to
        {
            get { return _to; }
            set { _to = value; }
        }

        [XmlAttribute("usessl")]
        public bool usessl
        {
            get { return _usessl; }
            set { _usessl = value; }
        }

        [XmlAttribute("sendmail")]
        public bool sendmail
        {
            get { return _sendmail; }
            set { _sendmail = value;}
        }

        public EmailMap clone()
        {
            return this.MemberwiseClone() as EmailMap;
        }
    }
}
