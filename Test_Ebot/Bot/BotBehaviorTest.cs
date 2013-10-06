using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull;
using ru.xnull.Exchanger;
using System.IO;
using ru.xnull.NetTools;
using Test_Ebot.Config;
using Rhino.Mocks;
using Test_Ebot.Exchanger;
using ru.xnull.ExchangerAPI;
using System.Xml;
using System.Xml.Linq;
using ru.xnull.Config.Mapping;
using ru.xnull.XML;
using ru.xnull.Config.Mapping.Bot;
using ru.xnull.ebot.Bot.Algorithm;
using ru.xnull.bot;
using ru.xnull.config;
using ru.xnull.ebot.Bot;

namespace Test_Ebot.Bot
{
    [TestFixture]
    class BotBehaviorTest
    {
        private MockRepository mocks;
        private INetSender netSenderMock;
        private IExchangerUtils exchUtilsMock;

        [SetUp]
        public void setUp()
        {
            mocks = new MockRepository();
            netSenderMock = mocks.StrictMock<INetSender>();
            exchUtilsMock = mocks.StrictMock<IExchangerUtils>();            
        }

        [Test]
        public void newBehavorTest()
        {
            /** Создаем заглушку конфига */ 
            createConfigStub();
            
            /** создаем заглушки списков выставленных заявок на бирже, по направления бакс убль и рубль бакс */
            ListBids listBids1Stub = createListBidsStub_exchType1();
            ListBids listBids2Stub = createListBidsStub_exchType2();

            /** создаем заглушки ответов сервера о удачно выставленных заявках на биржу */
            ResponseMap newPayResponseStub = createNewPayResponseStub(1);
            ResponseMap newPayResponseStub2 = createNewPayResponseStub(2);
            
            /** подпихиваем фейковый хттп клиент, который будет возращать фейковые списки обмена, вместо списков с сайта */
            ListBidsDao listBidsDao = new ListBidsDao(netSenderMock);

            WmidsMap wmids = ConfigDao.Instance().configMap.wmids;
            Spread spread = new Spread("WMZ_WMR__WMR_WMZ", 0.5);
            BotBehavior botBehavior = new BotBehavior(wmids, exchUtilsMock, listBidsDao, spread);

            /** возращаем по запросу фейковые списки обмена, вместо обменов с биржи */
            Expect.Call(netSenderMock.sendGetData(ListBidsDao.url + "?exchtype=1")).Return(listBids1Stub.ToString());
            Expect.Call(netSenderMock.sendGetData(ListBidsDao.url + "?exchtype=2")).Return(listBids2Stub.ToString());

            /** возращаем фейковый ответ сервера, о удачно выставленных заявках на бирже */
            Expect.Call(exchUtilsMock.newPay(new NewMyPayParameters(null,null,null,null,null))).IgnoreArguments().Return(newPayResponseStub);
            Expect.Call(exchUtilsMock.newPay(new NewMyPayParameters(null, null, null, null, null))).IgnoreArguments().Return(newPayResponseStub2);
            mocks.ReplayAll();
                        
            
            
            /** очищаем в конфиге все бехавиоры и проверяем очистился ли конфиг*/
            clearBehaviorsInConfig();
            Assert.AreEqual(ConfigDao.Instance().configMap.botMap.behaviors.Count, 0);

            /** создаем новый бехавиор и выставляем на биржу заявки */
            botBehavior.addParameter("spread", spread);
            botBehavior.setSuccessor(new ChainSuccessorMock());
            botBehavior.handle();

            String behaviorGuid = botBehavior.createdBehaviorGuid;
            
            
            /** ищем созданный бехавиор в конфиге, и проверяем его на корректность */
            BehaviorMap createdBehavior = findBehaviorByGuid(behaviorGuid);
            Assert.NotNull(createdBehavior);
            Assert.AreEqual(createdBehavior.payCount, 2);
            Assert.AreEqual(createdBehavior.paysMap.Count, 2);
            Assert.AreEqual(createdBehavior.paysMap[0].operid, 1588091);
        }

        private void clearBehaviorsInConfig()
        {
            ConfigDao.Instance().configMap.botMap.behaviors = new List<BehaviorMap>();
            ConfigDao.Instance().saveAndReloadConfig();
        }

        private BehaviorMap findBehaviorByGuid(String guid)
        {
            foreach (BehaviorMap currBehMap in ConfigDao.Instance().configMap.botMap.behaviors)
            {
                if (currBehMap.guid.Equals(guid))
                {
                    return currBehMap;
                }
            }
            return null;
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

        private void createConfigStub()
        {
            ConfigStubFactory configFactory = new ConfigStubFactory();
            configFactory.createConfigHaveRealCrypter();
        }
    }
}
