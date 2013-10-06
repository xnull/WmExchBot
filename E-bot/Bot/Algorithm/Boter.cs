using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Threading;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.NetTools;
using ru.xnull.Exchanger;
using ru.xnull.CentroBank;
using ru.xnull.Config.Mapping;
using ru.xnull.Config.Mapping.Bot;

using ru.xnull.XmlInterfaces;
using ru.xnull.ebot.Bot.Algorithm;
using ru.xnull.ExchangerAPI;
using log4net;
using ru.xnull.bot;
using ru.xnull.config;
using ru.xnull.exchangerapi;
using ru.xnull.ebot.bot;


namespace ru.xnull.ebot.Bot
{
    /// <summary>
    /// Главный класс бота
    /// </summary>
    class Boter : Threaded
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Boter));

        private INetSender netSender;
        private Torgi torgi;
        private ConfigMap configMap;
        private CbrDao cbrDao;
        private IListBidsDao listBidsDao;
        private ListMyPaysDao listMyPaysDao;
                

        /// <summary>
        /// Инициализация всех нужных инструментов(классов) для бота
        /// </summary>
        private void init()
        {
            ConfigDao.Instance().saveAndReloadConfig();

            NetMap net = ConfigDao.Instance().configMap.netMap;
            netSender = new NetSender(net.proxyMap, net.tryConnect);

            listBidsDao = new ListBidsDao(netSender);
            torgi = new Torgi(listBidsDao);
            configMap = ConfigDao.Instance().configMap;
            cbrDao = new CbrDao(netSender);
            listMyPaysDao = new ListMyPaysDao(netSender);
        }

        public void start()
        {
            init();
                        
            //Начало запуска цепочки
            Chain botStarter = new BotStarter(configMap.botMap);
            Chain behaviorExsistChecker = new BehaviorExsistChecker(configMap.botMap.behaviors);
            Chain behaviorsChecker = createBehaviorsChecker();
            Chain exchCalc = createCalculator();
            Chain botBehavior = createBotBehavior();
            Chain myPayPositionCorrector = createMyPayPositionCorrector();
            Chain behaviorArchiver = createBehaviorArchiver();
            Chain minimalRateSetter = new MinimalRate(torgi);

            try
            {
                //если бот запущен, передаем управление проверятелю - есть ли в конфиге бехавиоры
                botStarter.setSuccessor(behaviorExsistChecker);

                //если в конфиге существуют бехавиоры, то проверяем их на корректност
                behaviorExsistChecker.setSuccessor(behaviorsChecker);
                //после проверки всех бехавиоров на корректность, 
                //передаем управление корректору позиции заявок на бирже
                behaviorsChecker.setSuccessor(myPayPositionCorrector);
                myPayPositionCorrector.setSuccessor(behaviorArchiver);

                //если бехавиоров нет в конфиге, то выставляем новый бехавиор
                behaviorExsistChecker.setFailer(exchCalc);
                exchCalc.setSuccessor(botBehavior);
                botBehavior.setSuccessor(minimalRateSetter);
            }
            catch (Exception err)
            {
                log.Fatal("Критическая ошибка при запуске. Бот не будет запущен", err);
                return;
            }

            log.Info("Cтартует бот");
            try
            {
                botStarter.handle();
            }
            catch (Exception err)
            {
                log.Fatal("Критическая ошибка во время работы. Бот будет остановлен", err);
                return;
            }
            log.Info("Бот отработал");
        }

        private Chain createBehaviorArchiver()
        {
            Chain behaviorArchiver = new BehaviorArchiver(ConfigDao.Instance(), listMyPaysDao);
            return behaviorArchiver;
        }

        private Chain createMyPayPositionCorrector()
        {
            Chain myPayPositionCorrector = new MyPayPositionCorrector(configMap, listMyPaysDao);
            return myPayPositionCorrector;
        }

        private Chain createCalculator()
        {
            WmXmlInterfaces wmIfaces = new WmXmlInterfaces(netSender);
            Calculator exchCalc = new Calculator(cbrDao, configMap.wmids.getJobWmidMap(), wmIfaces, listBidsDao);
            return exchCalc;
        }

        private Chain createBotBehavior()
        {
            SpreadCalc SpreadCalc = new SpreadCalc(listBidsDao);
            IExchangerUtils exchUtils = new ExchangerUtils(netSender);
            WmidsMap wmids = configMap.wmids;

            BotBehavior botBehavior = new BotBehavior(wmids, exchUtils, listBidsDao, SpreadCalc.GetSpread("WMZ_WMR__WMR_WMZ"));

            return botBehavior;
        }

        private Chain createBehaviorsChecker()
        {
            ExchangerUtils exchange = new ExchangerUtils(netSender);
            BehaviorsChecker checker = new BehaviorsChecker(configMap, exchange, listBidsDao, netSender, torgi);
            return checker;
        }
    }
}
