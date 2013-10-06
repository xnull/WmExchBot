using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull;
using ru.xnull.XML;
using ru.xnull.Config.Mapping;
using System.Xml;

namespace Test_Ebot.Config.Mapper
{
    [TestFixture]
    class WmidMapTest
    {
        [Test]
        public void testWmidMap()
        {
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(@"Resources\Config.xml");
            
            String wmidXmlString = xmlConfig.SelectSingleNode("//wmids/wmid[@wmid='375930844466']").OuterXml;
            
            XmlMapper mapper = new XmlMapper();
            WmidMap wmidMap = mapper.xmlStringToClass<WmidMap>(wmidXmlString);
            Assert.AreEqual(wmidMap.authType, "Classic");
            Assert.AreEqual(wmidMap.number, "375930844466");
            Assert.AreEqual(wmidMap.purses.Count, 2);
            Assert.AreEqual(wmidMap.wmKeys, "qIGE=");
            Assert.NotNull(wmidMap.getPurseByType("WMR"));
            Assert.Null(wmidMap.getPurseByType("XXX"));            
        }
    }
}
