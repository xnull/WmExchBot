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
    class ListBidsMapTest
    {
        [Test]
        public void testAndCheckListBids()
        {
            XmlDocument listBidsXmlDoc = new XmlDocument();
            listBidsXmlDoc.Load("Resources\\Exchanger\\ListBids.xml");

            String bidXmlString = listBidsXmlDoc.SelectSingleNode("//WMExchnagerQuerys").OuterXml;
            
            XmlMapper mapper = new XmlMapper();
            ListBidsMap bMap = mapper.xmlStringToClass<ListBidsMap>(bidXmlString);
            
            Assert.AreEqual(bMap.bids.Count, 50);            
        }
    }
}
