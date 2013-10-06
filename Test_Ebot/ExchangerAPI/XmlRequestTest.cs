using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull.ExchangerAPI;
using System.Xml;

namespace Test_Ebot.ExchangerAPI
{
    [TestFixture]
    class XmlRequestTest
    {
        [Test]
        public void testBuild()
        {
            XmlRequest xmlRequest = new XmlRequest("123");
            xmlRequest.appendNode("signstr", "signstr");
            xmlRequest.appendNode("operid", "operid");
            xmlRequest.appendNode("curstype", "curstype");
            xmlRequest.appendNode("cursamount", "cursamount");

            XmlDocument xmlRequestDocument = new XmlDocument();
            xmlRequestDocument.LoadXml(xmlRequest.ToString());

            Assert.AreEqual(xmlRequestDocument.DocumentElement.Name, "wm.exchanger.request");
            Assert.AreEqual(xmlRequestDocument.SelectSingleNode("//signstr").InnerText, "signstr");
        }
    }
}
