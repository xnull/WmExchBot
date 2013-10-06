using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull.CentroBank;
using Rhino.Mocks;
using ru.xnull.NetTools;
using System.Xml;

namespace Test_Ebot
{
    [TestFixture]
    class CbrDAOTest
    {
        INetSender _netSendeMock;

        [SetUp]
        public void setUp()
        {
            _netSendeMock = new MockRepository().StrictMock<INetSender>();            
        }

        [Test]
        public void resultUrlTest()
        {            
            CbrDao cbrDao = new CbrDao(_netSendeMock);
            Assert.AreEqual(cbrDao.getResultUrl(DateTime.Now), "http://www.cbr.ru/scripts/XML_daily.asp");

            DateTime tomorrow = DateTime.Now.AddDays(1);
            String urlTomorrow = "http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + tomorrow.ToShortDateString();
            Assert.AreEqual(cbrDao.getResultUrl(DateTime.Now.AddDays(1)), urlTomorrow);
        }

        [Test]
        public void getCbrTest()
        {
            XmlDocument cbrRatesXmlDoc = new XmlDocument();
            cbrRatesXmlDoc.Load("Resources\\CentroBank\\cbrRates.xml");

            Expect.Call(_netSendeMock.sendGetData("")).Return(cbrRatesXmlDoc.OuterXml).IgnoreArguments();
            _netSendeMock.Replay();
            
            CbrDao cbrDao = new CbrDao(_netSendeMock);
            CbrMap cbr = cbrDao.getCbr(DateTime.Now);

            Assert.NotNull(cbr);
        }
    }
}
