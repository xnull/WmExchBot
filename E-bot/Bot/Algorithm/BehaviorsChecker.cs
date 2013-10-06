using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Exchanger;
using ru.xnull.Config.Mapping.Bot;
using ru.xnull.ExchangerAPI;

using ru.xnull.XmlInterfaces;
using ru.xnull.Config.Mapping;
using ru.xnull.NetTools;
using log4net;
using ru.xnull.config;
using ru.xnull.exchangerapi;
using ru.xnull.exchanger;
using ru.xnull.Bot;

namespace ru.xnull.ebot.Bot.Algorithm
{
    class BehaviorsChecker : Chain
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BehaviorsChecker));

        private ExchangerUtils exchange;
        private IListBidsDao listBidsDao;
        private INetSender netSender;
        private Torgi torgi;
        private ConfigMap configMap;

        public BehaviorsChecker(ConfigMap configMap, ExchangerUtils exchange, IListBidsDao listBidsDao, INetSender netSender, Torgi torgi)
        {
            this.configMap = configMap;
            this.exchange = exchange;
            this.listBidsDao = listBidsDao;
            this.netSender = netSender;
            this.torgi = torgi;
        }

        /// <summary>
        /// Поверить все бехавиоры в конфиге - если в них нехватает чего то - добавить.
        /// 
        /// </summary>
        public override bool handle()
        {
            log.Debug("Проверить все бехавиоры в конфиге, если какие нибудь из них не полные (не хватает заявок), то выставить заявки не хватающие в бехавиоре");
            List<BehaviorMap> Behaviours = configMap.botMap.behaviors;

            foreach (BehaviorMap currBehaviour in Behaviours)
            {
                if (currBehaviour.planPayCount != 2)
                {
                    logBehaviorPlanPay(currBehaviour);
                }
                if (currBehaviour.payCount != 2)
                {
                    logRealPayCountNotValid(currBehaviour);
                }

                List<String> MissingPays = getMissingPaysForBehavior(currBehaviour);

                //поставить недостающие заявки высчитав выгодный курс
                if (MissingPays.Count > 0)
                {
                    log.Info("Найден некорректный \"обмен\". Его идентификатор: " + currBehaviour.guid);
                }

                foreach (string currMissingPay in MissingPays)
                {
                    
                    NewMyPayParameters newMyPayParam = createNeyMyPayParameters(currMissingPay);
                    ResponseMap newMyPayResp = createMisingMyPay(newMyPayParam);
                    if (newMyPayResp == null)
                    {
                        continue;
                    }

                    if (newMyPayResp.retval.status == 0)
                    {
                        log.Info("Недостающая заявка добавлена к обмену: " + currBehaviour.guid + " номер заявки: " + newMyPayResp.retval.operid);
                        createBehaviorPay(currBehaviour, currMissingPay, newMyPayParam, newMyPayResp);
                    }
                }
            }

            return successor.handle();
        }

        /// <summary>
        /// Создать BehaviorPayMap на основе ответа полученного от сервера, когда я созадю новую заявку.
        /// И сохранить BehaviorPayMap в конфиг 
        /// </summary>
        /// <param name="currBehaviour"></param>
        /// <param name="currMissingPay"></param>
        /// <param name="newMyPayParam"></param>
        /// <param name="newMyPayResp"></param>
        private void createBehaviorPay(BehaviorMap currBehaviour, string currMissingPay, NewMyPayParameters newMyPayParam, ResponseMap newMyPayResp)
        {
            log.Debug("Создать BehaviorPayMap на основе ответа полученного от сервера, когда я созадю новую заявку. И сохранить BehaviorPayMap в конфиг ");
            string operid = newMyPayResp.retval.operid.ToString();
            //добавить платеж в бехавиор                        
            ExchType etype = new ExchType();
            ListBids lb = listBidsDao.getListBids(etype.GetExchTypeFromDirection(currMissingPay));

            BehaviorPayCreator behaviorPayCreator = new BehaviorPayCreator();
            BehaviorPayMap behPay = behaviorPayCreator.createBehaviorPay(configMap.wmids.getJobWmidMap().number, int.Parse(newMyPayResp.retval.operid), lb, newMyPayParam);
            currBehaviour.paysMap.Add(behPay);

            logCreateMissingPay(newMyPayResp);
            ConfigDao.Instance().saveAndReloadConfig();
        }

        /// <summary>
        /// Выставить новую заяву на бирже, для бехавиора в котором не хватает заявки
        /// </summary>
        /// <param name="newMyPayParam"></param>
        /// <returns></returns>
        private ResponseMap createMisingMyPay(NewMyPayParameters newMyPayParam)
        {
            ResponseMap newPay = null;
            try
            {                
                newPay = exchange.newPay(newMyPayParam);
            }
            catch (Exception err)
            {
                log.Error("Не смог выставить заявку на обмен.", err);
            }
            return newPay;
        }

        /// <summary>
        /// Получаем список заявок которые надо выставить на продажу для того чтобы бехавиор стал корректным
        /// </summary>
        /// <param name="currBehaviour"></param>
        /// <returns></returns>
        private List<string> getMissingPaysForBehavior(BehaviorMap currBehaviour)
        {
            List<string> MissingPays = new List<string>();
            MissingPays.Clear();
            MissingPays = currBehaviour.getMissingPays();
            return MissingPays;
        }

        /// <summary>
        /// Создать класс параметров для выставления новой заявки на биржу
        /// </summary>
        /// <param name="missingPay">требуемый платеж - WMZ_WMR например</param>
        /// <returns></returns>
        private NewMyPayParameters createNeyMyPayParameters(string missingPay)
        {
            String wmidNumber = configMap.wmids.getJobWmidMap().number;

            int exchtype = getExchTypeFromMissingPay(missingPay);
            double Rate = getRate(exchtype);

            PursesFromDirection pursesFromDirection = new PursesFromDirection(missingPay);

            double inamount = getInAmount(pursesFromDirection);

            double outamount = torgi.outamountForInamount(exchtype, inamount, Rate);
            String inpurse = pursesFromDirection.Job_InPurse;
            String outPurse = pursesFromDirection.Job_OutPurse;
            NewMyPayParameters newMyPayParam = new NewMyPayParameters(wmidNumber, inpurse, outPurse, inamount.ToString(), outamount.ToString());
            return newMyPayParam;
        }

        /// <summary>
        /// Получить сумму для обмена
        /// </summary>
        /// <param name="PursesFromDirection"></param>
        /// <returns></returns>
        private double getInAmount(PursesFromDirection PursesFromDirection)
        {
            log.Info("Получаем сумму для выставления на биржу. Тип кошелька: " + PursesFromDirection.InPurseType);
            WmidMap jobWmid = configMap.wmids.getJobWmidMap();
            WmXmlInterfaces xmlInterfaces = new WmXmlInterfaces(netSender);
                        
            BalanceForBot balancer = new BalanceForBot(xmlInterfaces);
            int inamount = balancer.getBalance(jobWmid, PursesFromDirection.InPurseType);

            return inamount;
        }

        private int getExchTypeFromMissingPay(string missingPay)
        {
            int exchtype = new ExchType().GetExchTypeFromDirection(missingPay);
            return exchtype;
        }

        private double getRate(int exchtype)
        {
            double Rate = torgi.getRateForPosition(exchtype, 45);
            return Rate;
        }

        /// <summary>
        /// Запись в лог создания недостающего платежа в бехавиоре
        /// </summary>
        /// <param name="newPay"></param>
        private void logCreateMissingPay(ResponseMap newPay)
        {
            StringBuilder logMessage = new StringBuilder("Пытаемся выставить недостающую заявку для \"обмена\"");
            logMessage.AppendLine("Результат (если 0, то успешно): " + newPay.retval.status);
            logMessage.AppendLine("Описание: " + newPay.retdesc);
            logMessage.AppendLine("id заявки" + newPay.retval.operid);
            log.Info(logMessage.ToString());
        }

        private void logRealPayCountNotValid(BehaviorMap currBehaviour)
        {
            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendLine("В обмене " + currBehaviour.fullDirections + " " + currBehaviour.guid);
            logMessage.AppendLine("Количество реально выставленных заявок не равно двум, поэтому бот не будет обрабатывать такой \"обмен\"");
            log.Warn(logMessage.ToString());
        }

        private void logBehaviorPlanPay(BehaviorMap currBehaviour)
        {
            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendLine("В обмене " + currBehaviour.fullDirections + " " + currBehaviour.guid);
            logMessage.AppendLine("Количество плановых заявок не равно двум, поэтому бот не будет обрабатывать такой \"обмен\"");
            log.Warn(logMessage.ToString());
        }
    }
}
