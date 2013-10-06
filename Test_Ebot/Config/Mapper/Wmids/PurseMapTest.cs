using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull;
using ru.xnull.XML;
using System.Xml;
using ru.xnull.config.mapping;

namespace Test_Ebot.Config.Mapper
{
    [TestFixture]
    class PurseMapTest
    {
        [Test]
        public void testPurseMap()
        {
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(@"Resources\Config.xml");
            String purseString = xmlConfig.SelectSingleNode("//wmids/wmid[@wmid='375930844466']").SelectSingleNode("//purse[@type='WMR']").OuterXml;
            
            XmlMapper mapper = new XmlMapper();
            PurseMap purseMap = mapper.xmlStringToClass<PurseMap>(purseString);
            
            Assert.AreEqual(purseMap.type, "WMR");
            Assert.AreEqual(purseMap.minSumm, 1000);
            Assert.AreEqual(purseMap.summForExch, 5);
            Assert.AreEqual(purseMap.number, "R675010658902");
        }
    }
}
