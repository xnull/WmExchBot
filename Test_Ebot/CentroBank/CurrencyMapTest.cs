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
    class CurrencyMapTest
    {
        [Test]
        public void mapTest()
        {
            XmlDocument cbrDoc = new XmlDocument();
            cbrDoc.Load("Resources\\CentroBank\\cbrRates.xml");

            XmlMapper mapper = new XmlMapper();
            CurrencyMap currMap = mapper.xmlStringToClass<CurrencyMap>(cbrDoc.SelectSingleNode("//Valute").OuterXml);

            Assert.AreEqual(currMap.id, "R01010");
            Assert.AreEqual(currMap.NumCode, "036");
            Assert.AreEqual(currMap.CharCode, "AUD");
            Assert.AreEqual(currMap.Nominal, 1);
            Assert.AreEqual(currMap.Name, "Австралийский доллар");
            Assert.AreEqual(currMap.rate, "29,3687");
            
        }
    }
}
