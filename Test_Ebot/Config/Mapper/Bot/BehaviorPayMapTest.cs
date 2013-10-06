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
    class BehaviorPayMapTest
    {
        [Test]
        public void testBehaviorPayMap()
        {
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(@"Resources\Config.xml");
            
            String payString = xmlConfig.SelectSingleNode("//Bot/Behaviors/Behavior/pay").OuterXml;

            XmlMapper mapper = new XmlMapper();
            BehaviorPayMap payMap = mapper.xmlStringToClass<BehaviorPayMap>(payString);

            Assert.AreEqual(payMap.currentPlanPosition, 45);
            Assert.AreEqual(payMap.beginDate, "13.11.2009 16:29:14");
            Assert.AreEqual(payMap.minRate, "29,719");
        }
    }
}
