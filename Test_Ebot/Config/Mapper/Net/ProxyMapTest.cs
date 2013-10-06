using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull;
using ru.xnull.XML;
using ru.xnull.Config.Mapping.Net;
using System.Xml;

namespace Test_Ebot.Config.Mapper.Net
{
    [TestFixture]
    class ProxyMapTest
    {
        [Test]
        public void testProxy()
        {
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(@"Resources\Config.xml");
            
            String proxyString = xmlConfig.SelectSingleNode("//Net/Proxy").OuterXml;

            XmlMapper mapper = new XmlMapper();
            ProxyMap proxyMap = mapper.xmlStringToClass<ProxyMap>(proxyString);

            Assert.AreEqual(proxyMap.ip, "192.168.1.1:8080");
            Assert.AreEqual(proxyMap.login, "null");
            Assert.AreEqual(proxyMap.pass, "testpass");
            Assert.AreEqual(proxyMap.useProxy, true);
           
        }
    }
}
