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
    class NetMapTest
    {
        [Test]
        public void testNetMap()
        {
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(@"Resources\Config.xml");
            
            String netString = xmlConfig.SelectSingleNode("//Net").OuterXml;

            XmlMapper mapper = new XmlMapper();
            NetMap netMap = mapper.xmlStringToClass<NetMap>(netString);

            Assert.AreEqual(netMap.tryConnect, 5);
            Assert.NotNull(netMap.emailMap);
            Assert.NotNull(netMap.proxyMap);
        }
    }
}
