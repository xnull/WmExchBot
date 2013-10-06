using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml;
using ru.xnull.Exchanger;
using ru.xnull.XML;
using ru.xnull.Exchanger.XmlMapping;

namespace Test_Ebot.Exchanger.XmlMapping
{
    [TestFixture]
    class BidMapTest
    {
        [Test]
        public void testAndCheckBid()
        {
            XmlDocument listBidsXmlDoc = new XmlDocument();
            listBidsXmlDoc.Load("Resources\\Exchanger\\ListBids.xml");

            String bidXmlString = listBidsXmlDoc.SelectSingleNode("//WMExchnagerQuerys/query").OuterXml;
            
            XmlMapper mapper = new XmlMapper();
            BidMap bMap = mapper.xmlStringToClass<BidMap>(bidXmlString);


            Assert.AreEqual(bMap.allamountin, "1480");
            Assert.AreEqual(bMap.amountin, "1480");
            Assert.AreEqual(bMap.amountout, "45317,6");
            Assert.AreEqual(bMap.id, 4902843);
            Assert.AreEqual(bMap.inoutrate, "0,0326");
            Assert.AreEqual(bMap.outinrate, "30,62");
            Assert.AreEqual(bMap.querydate, "04.02.2011 5:33:56");
            Assert.AreEqual(bMap.procentbankrate, "+4,33");
        }
    }
}
