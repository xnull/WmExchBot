using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml;
using ru.xnull.XML;
using ru.xnull.XmlInterfaces.Response;

namespace Test_Ebot.XmlInterfaces.History.Response
{
    [TestFixture]
    class HistoryMapTest
    {
        [Test]
        public void checkHistory()
        {
            XmlDocument xmlHistory = new XmlDocument();
            xmlHistory.Load(@"Resources\XmlInterfaces\X3_History\Response.xml");

            XmlMapper mapper = new XmlMapper();
            HistoryMap history = mapper.xmlStringToClass<HistoryMap>(xmlHistory.OuterXml);

            Assert.AreEqual(history.reqn, 1);            
            Assert.AreEqual(history.retdesc, String.Empty);
            Assert.AreEqual(history.retval, "0");
            Assert.NotNull(history.operations);

            Assert.AreEqual(history.operations.cnt, 1);
            Assert.AreEqual(history.operations.operationsList[0].id, 504424913);
        }
    }
}
