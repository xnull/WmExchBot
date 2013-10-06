using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull.Config.Mapping;
using ru.xnull.XML;
using ru.xnull;
using System.Xml;

namespace Test_Ebot.Config.Mapper
{
    [TestFixture]
    class ConfigMapTest
    {
        [Test]
        public void testConfig()
        {
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(@"Resources\Config.xml");
            
            XmlMapper mapper = new XmlMapper();
            ConfigMap config = mapper.xmlStringToClass<ConfigMap>(xmlConfig.OuterXml);
            
            Assert.NotNull(config.wmids);
            Assert.AreEqual(config.wmids.getJobWmidMap().number, "375930844466");
            Assert.AreEqual(config.wmids.wmidList.Count, 1);
            Assert.NotNull(config.netMap);
            Assert.NotNull(config.botMap);

            Assert.AreEqual(config.archiveMap.Count, 1);

        }
    }
}
