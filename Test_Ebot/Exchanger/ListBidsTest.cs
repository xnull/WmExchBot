using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull.Exchanger;
using System.Xml;

namespace Test_Ebot.Exchanger
{
    [TestFixture]
    class ListBidsTest
    {
        [Test]
        public void checkListBidsAndBid()
        {
            XmlDocument listBidsXmlDoc = new XmlDocument();
            listBidsXmlDoc.Load("Resources\\Exchanger\\ListBids.xml");
            ListBids listBids = new ListBids(1, listBidsXmlDoc);

            Assert.AreEqual(listBids.Count, 50);
            Assert.AreEqual(listBids.Direction, "WMZ_WMR");
            Assert.AreEqual(listBids.ExchType, 1);
            Assert.AreEqual(listBids.InPurse_Type, "WMZ");
            Assert.AreEqual(listBids.OfficalRate, 29.3489);
            Assert.AreEqual(listBids.OutPurse_Type, "WMR");
            Assert.AreEqual(listBids.ReverseExchType, 2);
            Assert.AreEqual(listBids.ToString(), listBidsXmlDoc.OuterXml);
        }
    }
}
