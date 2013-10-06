using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull.XmlInterfaces;
using ru.xnull;
using ru.xnull.NetTools;
using Rhino.Mocks;
using ru.xnull.XmlInterfaces.Request;
using ru.xnull.XmlInterfaces.Response;
using System.Xml;
using ru.xnull.Config.Mapping;

namespace Test_Ebot
{
    [TestFixture]
    class XmlInterfacesTest
    {
        private MockRepository mocks;
        private INetSender netSenderMock;

        [SetUp]
        public void setUp()
        {
            mocks = new MockRepository();
            netSenderMock = mocks.StrictMock<INetSender>();
        }

        [Test]
        public void testInterface()
        {
            XmlDocument siteReqsponce = new XmlDocument();
            siteReqsponce.Load(@"Resources\XmlInterfaces\X3_History\Response.xml");

            X3RequestMap request = createX3Request();

            Expect.Call(netSenderMock.sendPostData("", "")).Return(siteReqsponce.OuterXml).IgnoreArguments();
            mocks.ReplayAll();

            WmXmlInterfaces xmlInterfaces = new WmXmlInterfaces(netSenderMock);
            HistoryMap history = xmlInterfaces.X3_History(request);

            Assert.AreEqual(history.retval, "0");

            //WmidMap wmidMap = new WmidMap();
            //wmidMap.wmKeys = "123";
            //double balance = xmlInterfaces.getBalance(wmidMap, "R123");
            //Assert.AreEqual(balance, 0);

        }

        private X3RequestMap createX3Request()
        {
            X3RequestMap request = new X3RequestMap();

            GetOperationsRequestMap operationsRequest = new GetOperationsRequestMap();
            operationsRequest.purse = "R123";
            operationsRequest.datestart = "20110310 00:00";
            operationsRequest.datefinish = "20110311 00:00";

            request.getOperations = operationsRequest;
            request.reqn = 1;
            request.sign = "signedString";
            request.wmid = "12345";
            return request;
        }
    }
}
