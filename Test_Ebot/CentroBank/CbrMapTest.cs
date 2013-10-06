using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ru.xnull.CentroBank;
using System.Xml;
using ru.xnull.XML;

namespace Test_Ebot.CentroBank
{
    [TestFixture]
    class CbrMapTest
    {
        [Test]
        public void mapTest()
        {
            XmlDocument cbrDoc = new XmlDocument();
            cbrDoc.Load("Resources\\CentroBank\\cbrRates.xml");

            XmlMapper mapper = new XmlMapper();
            CbrMap cbrMap = mapper.xmlStringToClass<CbrMap>(cbrDoc.OuterXml);

            Assert.AreEqual(cbrMap.date, "29.01.2011");
            Assert.AreEqual(cbrMap.currencyList.Count, 35);
            Assert.AreEqual(cbrMap.getCurrency("USD").rate, "29,6684");
            Assert.IsNull(cbrMap.getCurrency("Expected"));
        }
    }
}
