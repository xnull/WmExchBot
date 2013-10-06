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
    class BotMapTest
    {
        [Test]
        public void testBotMap()
        {
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(@"Resources\Config.xml");
            
            String botString = xmlConfig.SelectSingleNode("//Bot").OuterXml;

            XmlMapper mapper = new XmlMapper();
            BotMap botMap = mapper.xmlStringToClass<BotMap>(botString);

            Assert.AreEqual(botMap.job, true);
            Assert.AreEqual(botMap.reflectZayavkaTimeout, 35);
            Assert.AreEqual(botMap.minutesTimeout, 3);
            Assert.AreEqual(botMap.behaviors.Count, 1);

            Assert.AreEqual(botMap.behaviors[0].paysMap.Count, 2);
        }
    }
}
