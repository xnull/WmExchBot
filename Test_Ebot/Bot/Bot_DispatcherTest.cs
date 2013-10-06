using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull;
using Rhino.Mocks;
using ru.xnull.Exchanger;
using Test_Ebot.Exchanger;

namespace Test_Ebot.Bot
{
    [TestFixture]
    class Bot_DispatcherTest
    {
        [Test]
        public void testDuspatcher()
        {
            Torgi torgi = createAndInitTorgi();
            //Bot_Dispatcher botDispatcher = new Bot_Dispatcher(torgi,

        }

        private Torgi createAndInitTorgi()
        {
            MockRepository mocks = new MockRepository();
            IListBidsDao listBidsDaoMock = mocks.DynamicMock<IListBidsDao>();
            ListBids listBidsStub = getListBids();

            Expect.Call(listBidsDaoMock.getListBids(listBidsStub.ExchType)).IgnoreArguments().Return(listBidsStub);
            mocks.ReplayAll();

            return new Torgi(listBidsDaoMock);
        }

        private ListBids getListBids()
        {
            ListBidsMocksFactory lbFactory = new ListBidsMocksFactory();
            ListBids listBidsStub = lbFactory.getListBidsStub_exchType1();
            return listBidsStub;
        }
    }
}
