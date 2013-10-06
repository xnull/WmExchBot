using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ru.xnull.CentroBank;
using System.Xml;
using ru.xnull;
using ru.xnull.XML;

namespace Test_Ebot
{
    [TestFixture]
    class TrialTest
    {
        private CbrMap cbr;

        [SetUp]
        public void setup()
        {
            XmlDocument cbrXmlRates = new XmlDocument();
            cbrXmlRates.Load(".\\Resources\\CentroBank\\cbrRates.xml");
            XmlMapper mapper = new XmlMapper();

            cbr = mapper.xmlStringToClass<CbrMap>(cbrXmlRates.OuterXml);
        }


        [Test]
        [Ignore("Ignore a test")]
        public void testIsExpired()
        {
            Trial trial = new Trial(cbr, DateTime.Parse(cbr.date).AddDays(-1), true);
            Assert.True(Trial.isTrialVersion());
            Assert.True(trial.isExpired());

            Trial trial2 = new Trial(null, DateTime.Now, true);
            Assert.True(trial2.isExpired());

            Trial trial3 = new Trial(cbr, DateTime.Parse(cbr.date).AddDays(10), true);
            Assert.False(trial3.isExpired());
        }
    }
}
