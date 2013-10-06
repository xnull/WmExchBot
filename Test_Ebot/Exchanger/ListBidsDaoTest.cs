using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using ru.xnull.NetTools;
using ru.xnull.Exchanger;
using System.Xml;

namespace Test_Ebot.Exchanger
{
    [TestFixture]
    class ListBidsDaoTest
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
        public void testDao()
        {
            XmlDocument listBidsXmlDoc = new XmlDocument();
            listBidsXmlDoc.Load("Resources\\Exchanger\\ListBids.xml");

            String answer = listBidsXmlDoc.OuterXml;
            Expect.Call(netSenderMock.sendGetData(ListBidsDao.url + "?exchtype=1")).Return(answer);
            mocks.ReplayAll();            

            ListBidsDao listBidsDao = new ListBidsDao(netSenderMock);
            ListBids listBidsResult = listBidsDao.getListBids(1);                        
                        
            Assert.AreEqual(answer, listBidsResult.ToString());
            //mocks.VerifyAll();            
        }
    }
}
