using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using NUnit.Framework;
using ru.xnull.ExchangerAPI;
using ru.xnull.XML;

namespace Test_Ebot.ExchangerAPI
{
    [TestFixture]
    class ResponseMapTest
    {

        [Test]
        public void testRetval()
        {
            XmlDocument newPayResponseXmlDoc = new XmlDocument();
            newPayResponseXmlDoc.Load("Resources\\ExchangerApi\\NewPayXmlResponse.xml");

            XmlMapper mapper = new XmlMapper();
            ResponseMap resp = mapper.xmlStringToClass<ResponseMap>(newPayResponseXmlDoc.OuterXml);
            Assert.AreEqual(resp.retval.status, 0);
            Assert.AreEqual(resp.retdesc, "test");
        }

        [Test]
        public void testResponceNewPayWithEncoding()
        {
            XmlDocument newPayResponseXmlDoc = new XmlDocument();
            newPayResponseXmlDoc.Load("Resources\\ExchangerApi\\ResponceFromSiteWithEncoding.xml");

            XmlMapper mapper = new XmlMapper();
            ResponseMap resp = mapper.xmlDocumentToClass<ResponseMap>(newPayResponseXmlDoc);
            Assert.AreEqual(resp.retval.status, -40);
            Assert.AreEqual(resp.retdesc, "Сумма, которую Вы хотите получить после обмена  слишком мала, укажите сумму большую или равную 30");
        }
    }
}
