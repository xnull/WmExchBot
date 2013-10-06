using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull;
using ru.xnull.XML;
using ru.xnull.Config.Mapping.Bot;
using System.Xml;

namespace Test_Ebot.Config.Mapper.Bot
{
    [TestFixture]
    class BehaviorMapTest
    {
        private BehaviorMap bMap;

        [SetUp]
        public void setUp()
        {
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(@"Resources\Config.xml");

            String behaviorString = xmlConfig.SelectSingleNode("//Bot/Behaviors/*").OuterXml;

            XmlMapper mapper = new XmlMapper();
            bMap = mapper.xmlStringToClass<BehaviorMap>(behaviorString);
        }

        [Test]
        public void checkMappingBehaviorMap()
        {
            Assert.AreEqual(bMap.fullDirections, "WMZ_WMR__WMR_WMZ");
            Assert.AreEqual(bMap.guid, "123");
            Assert.AreEqual(bMap.paysMap.Count, 2);            
        }

        [Test]
        public void checkGetMissingPays()
        {
            BehaviorMap behaviorMap = new BehaviorMap();
            behaviorMap.planPayCount = 2;
            behaviorMap.fullDirections = "WMZ_WMR__WMR_WMZ";

            BehaviorPayMap bPayMap = new BehaviorPayMap();
            bPayMap.direction = "WMZ_WMR";

            behaviorMap.paysMap = new List<BehaviorPayMap>();
            behaviorMap.paysMap.Add(bPayMap);

            List<String> missingPays = behaviorMap.getMissingPays();

            Assert.AreEqual(missingPays.Count, 1);
            Assert.AreEqual(missingPays[0], "WMR_WMZ");
        }
    }
}
