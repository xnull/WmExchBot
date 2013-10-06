using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace Test_Ebot
{
    /// <summary>
    /// Заглушка  конфига
    /// </summary>
    class ConfigStub
    {
        private XmlDocument xmlConfig;

        public ConfigStub()
        {
            xmlConfig = new XmlDocument();
            xmlConfig.Load("Resources\\Config.xml");
        }

        public XmlDocument getXmlDoc()
        {
            return xmlConfig;
        }
    }
}
