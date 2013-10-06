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
    class WmidsMapTest
    {

        [Test]
        public void testWmidsAttr()
        {
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(@"Resources\Config.xml");
            
            XmlMapper mapper = new XmlMapper();
            String wmidsXmlString = xmlConfig.SelectSingleNode("//wmids").OuterXml;

            WmidsMap wmidsMap = mapper.xmlStringToClass<WmidsMap>(wmidsXmlString);
            Assert.AreEqual(wmidsMap.getJobWmidMap().number, "375930844466");
            Assert.AreEqual(wmidsMap.wmidList.Count, 1);
            Assert.NotNull(wmidsMap.getWmid("375930844466"));
            Assert.Null(wmidsMap.getWmid("123")); 
        }
    }
}
