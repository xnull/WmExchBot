using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ru.xnull.CentroBank;
using System.Xml;
using ru.xnull;
using ru.xnull.XML;
using Rhino.Mocks;
using ru.xnull.Config.Mapping;
using ru.xnull.XmlInterfaces;
using Test_Ebot.Config;
using Test_Ebot.Bot;
using ru.xnull.ebot.Bot.Algorithm;
using ru.xnull.config;

using ru.xnull.ebot.webmoney;
using ru.xnull.Exchanger;
using Test_Ebot.Exchanger;
using ru.xnull.ExchangerAPI;
using ru.xnull.NetTools;
using ru.xnull.webmoney;

namespace Test_Ebot
{
    [TestFixture]
    class CalculatorTest
    {
        private MockRepository mocks;

        private ICbrDao _cbrDaoMock;
        private CbrMap _cbrStub;        

        private IWmXmlInterfaces wmIfacesStub;

        private ConfigDao config;

        private INetSender netSenderMock;

        [SetUp]
        public void setup()
        {
            mocks = new MockRepository();
            _cbrDaoMock = mocks.StrictMock<ICbrDao>();

            netSenderMock = mocks.StrictMock<INetSender>();

            config = new ConfigStubFactory().createConfigHaveRealCrypter();
            
            /**
             * cbr заглушка, возращает официальные курсы доллара и евро
             */
            _cbrStub = new CbrMap();
            _cbrStub.currencyList = new List<CurrencyMap>();
            _cbrStub.currencyList.Add(createCurrency("USD", "30"));
            _cbrStub.currencyList.Add(createCurrency("EUR", "40"));

            wmIfacesStub = mocks.StrictMock<IWmXmlInterfaces>();

        }


        [Test]
        public void testCalculator()
        {
            setBalancesForWmIfaces(100, 3);
            setBalancesForWmIfaces(100, 10);            
            mocks.ReplayAll();

            /** создаем заглушки списков выставленных заявок на бирже, по направления бакс убль и рубль бакс */
            ListBids listBids1Stub = createListBidsStub_exchType1();
            ListBids listBids2Stub = createListBidsStub_exchType2();

            /** создаем заглушки ответов сервера о удачно выставленных заявках на биржу */
            ResponseMap newPayResponseStub = createNewPayResponseStub(1);
            ResponseMap newPayResponseStub2 = createNewPayResponseStub(2);

            /** подпихиваем фейковый хттп клиент, который будет возращать фейковые списки обмена, вместо списков с сайта */
            ListBidsDao listBidsDao = new ListBidsDao(netSenderMock);

            Calculator calc = new Calculator(_cbrDaoMock, config.configMap.wmids.getJobWmidMap(), wmIfacesStub, listBidsDao);
            calc.setSuccessor(new ChainSuccessorMock());
            calc.handle();

            Assert.AreEqual(ConfigDao.Instance().configMap.wmids.getJobWmidMap().getPurseByType(WmCurrencyNames.WMR).summForExch, 77);
            Assert.AreEqual(ConfigDao.Instance().configMap.wmids.getJobWmidMap().getPurseByType(WmCurrencyNames.WMZ).summForExch, 2);

            Calculator calc2 = new Calculator(_cbrDaoMock, config.configMap.wmids.getJobWmidMap(), wmIfacesStub, listBidsDao);
            calc2.setSuccessor(new ChainSuccessorMock());
            calc2.handle();

            Assert.AreEqual(ConfigDao.Instance().configMap.wmids.getJobWmidMap().getPurseByType(WmCurrencyNames.WMR).summForExch, 99);
            Assert.AreEqual(ConfigDao.Instance().configMap.wmids.getJobWmidMap().getPurseByType(WmCurrencyNames.WMZ).summForExch, 5);

        }

        private void setBalancesForWmIfaces(Double wmrBalance, Double wmzBalance)
        {
            /**
             * возращаем нужные курсы цб
             */
            Expect.Call(_cbrDaoMock.getCbr(new DateTime())).Return(_cbrStub).IgnoreArguments();
            Expect.Call(_cbrDaoMock.getCbr(new DateTime())).Return(_cbrStub).IgnoreArguments();

            /**
             * баланс на кошельке - рублевый
             */
            Expect.Call(wmIfacesStub.getBalance(null, null)).Return(wmrBalance).IgnoreArguments();
            /**
             * баланс на кошельке - баксовый
             */
            Expect.Call(wmIfacesStub.getBalance(null, null)).Return(wmzBalance).IgnoreArguments();
        }

        private CurrencyMap createCurrency(String charCode, string rate)
        {
            CurrencyMap currency = new CurrencyMap();
            currency.CharCode = charCode;
            currency.rate = rate;
            return currency;
        }

        private ListBids createListBidsStub_exchType1()
        {
            ListBidsMocksFactory listBidsMockFactory = new ListBidsMocksFactory();
            return listBidsMockFactory.getListBidsStub_exchType1();
        }

        private ListBids createListBidsStub_exchType2()
        {
            ListBidsMocksFactory listBidsMockFactory = new ListBidsMocksFactory();
            return listBidsMockFactory.getListBidsStub_exchType2();
        }

        private ResponseMap createNewPayResponseStub(int stubNumber)
        {
            XmlDocument newPayResponseXmlDoc = new XmlDocument();

            String fileName = "Resources\\ExchangerApi\\NewPayXmlResponse.xml";
            if (stubNumber == 2)
            {
                fileName = "Resources\\ExchangerApi\\NewPayXmlResponse2.xml";
            }
            newPayResponseXmlDoc.Load(fileName);
            XmlMapper mapper = new XmlMapper();
            ResponseMap newPayResponse = mapper.xmlStringToClass<ResponseMap>(newPayResponseXmlDoc.OuterXml);
            return newPayResponse;
        }
    }
}
