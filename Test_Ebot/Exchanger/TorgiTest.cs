using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull;
using ru.xnull.Exchanger;
using Rhino.Mocks;
using System.Xml;
using Test_Ebot.Exchanger;

namespace Test_Ebot
{
    [TestFixture]
    class TorgiTest
    {
        [Test]
        public void testFindMyPosition()
        {
            MockRepository mocks = new MockRepository();
            IListBidsDao listBidsDaoMock = mocks.DynamicMock<IListBidsDao>();
            ListBids listBidsStub = getListBids();
                        
            Expect.Call(listBidsDaoMock.getListBids(listBidsStub.ExchType)).IgnoreArguments().Return(listBidsStub);
            mocks.ReplayAll();

            Torgi torgi = new Torgi(listBidsDaoMock);
            Assert.AreEqual(torgi.FindMyPosition(listBidsStub.ExchType, "4902843"), 1);
            Assert.AreEqual(torgi.getRateForPosition(listBidsStub.ExchType, 1), 30.62);

            Assert.AreEqual(torgi.ratePlusDelta(1, 30, 1), 31);
            Assert.AreEqual(torgi.ratePlusDelta(2, 30, 1), 29);

            Assert.AreEqual(torgi.getPositionForRate(listBidsStub.ExchType, 30.61), 1);

            Assert.AreEqual(torgi.outamountForInamount(1, 50, 5), 50*5);
            Assert.AreEqual(torgi.outamountForInamount(2, 50, 5), 50/5);
            //Assert.AreEqual(torgi.setMyPayPosition(listBidsStub.ExchType, 1, 30.5), 30);
            
        }


        private ListBids getListBids()
        {
            ListBidsMocksFactory lbFactory = new ListBidsMocksFactory();
            ListBids listBidsStub = lbFactory.getListBidsStub_exchType1();
            return listBidsStub;
        }
    }
}
