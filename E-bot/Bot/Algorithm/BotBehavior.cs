using System.Collections;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ru.xnull;
using ru.xnull.Exchanger;
using ru.xnull.ExchangerAPI;
using ru.xnull.NetTools;

using ru.xnull.Config.Mapping;
using ru.xnull.Config.Mapping.Bot;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.ebot.Bot;
using ru.xnull.Bot;
using log4net;
using ru.xnull.config;
using ru.xnull.calc;
using ru.xnull.ebot.calc;
using ru.xnull.ebot.webmoney;
using ru.xnull.webmoney;
using ru.xnull.ebot.Bot.Algorithm;

namespace ru.xnull.ebot.Bot
{
    /// <summary>
    /// Класс - поведение бота реализующее функциональность работы с бехавиором
    /// </summary>
    public class BotBehavior : Chain
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BotBehavior));

        private int positionOnExchanger = 45;
        private IExchangerUtils _exchangerUtils;
        private IListBidsDao _listBidsDao;
        private WmidsMap _wmidsMap;
        private Spread spread;

        private String _createdBehaviorGuid;

        public BotBehavior(WmidsMap wmids, IExchangerUtils exchUtils, IListBidsDao listBidsDao, Spread spread)
        {
            _exchangerUtils = exchUtils;
            _listBidsDao = listBidsDao;
            _wmidsMap = wmids;
            this.spread = spread;
        }

        /// <summary>
        /// Создать новый бехавиор
        /// </summary>
        /// <param name="wmid"></param>
        /// <param name="spread"></param>
        /// <returns>guid созданного бехавиора</returns>
        public override Boolean handle()
        {
            return createNewBehavior();
        }

        private bool createNewBehavior()
        {
            log.Info("Создаем \"обмен\"");
            String wmid = _wmidsMap.getJobWmidMap().number;
            BehaviorMap behavior = createNewBehaviorMap();

            //BehaviourExchanges - получаем списки обменов с торгов, по интересующим нас направлениям
            AllExchanges BehaviourExchanges = new AllExchanges(_listBidsDao, spread.GetExchTypes());

            foreach (ListBids currListBids in BehaviourExchanges)
            {
                NewMyPayParameters myPayParams = createMyPayParameters(currListBids);
                ResponseMap newPay = createNewMyPay(myPayParams);

                if (newPay.retval.status == ResponseMap.SUCCESS)
                {
                    BehaviorPayMap behPay = createBehaviorPay(wmid, int.Parse(newPay.retval.operid), currListBids, myPayParams);
                    behavior.paysMap.Add(behPay);
                }
                else
                {
                    logNewPayFail(newPay);
                }
            }

            //если бехавиор корректен, то сохранить его в конфиг
            ConfigDao.Instance().configMap.botMap.behaviors.Add(behavior);
            ConfigDao.Instance().saveAndReloadConfig();

            _createdBehaviorGuid = behavior.guid;

            return successor.handle();
        }

        public String createdBehaviorGuid
        {
            get
            {
                if (_createdBehaviorGuid == null)
                {
                    throw new Exception("Обмен не создан");
                }
                return _createdBehaviorGuid;
            }
        }

        /// <summary>
        /// Создаем новый бехавиор
        /// </summary>
        /// <returns></returns>
        private BehaviorMap createNewBehaviorMap()
        {
            BehaviorMap behavior = new BehaviorMap();
            behavior.paysMap = new List<BehaviorPayMap>();
            behavior.guid = BehaviorMap.generateGuid();
            behavior.planPayCount = 2;
            behavior.fullDirections = spread.FullDirection;
            return behavior;
        }

        //Добавить новую заявку в конфиг  
        private BehaviorPayMap createBehaviorPay(String wmid, int operId, ListBids listBids, NewMyPayParameters myPayParams)
        {
            BehaviorPayCreator behaviorPayCreator = new BehaviorPayCreator();
            return behaviorPayCreator.createBehaviorPay(wmid, operId, listBids, myPayParams);
        }

        /// <summary>
        /// Создать параметры для моего платежа
        /// </summary>
        /// <param name="listBids"></param>
        /// <returns></returns>
        private NewMyPayParameters createMyPayParameters(ListBids listBids)
        {
            string inpurse = _wmidsMap.getJobWmidMap().getPurseByType(listBids.InPurse_Type).number;
            string outpurse = _wmidsMap.getJobWmidMap().getPurseByType(listBids.OutPurse_Type).number;
            double inamount = Convert.ToDouble(_wmidsMap.getJobWmidMap().getPurseByType(listBids.InPurse_Type).summForExch);
            double outamount = listBids[positionOnExchanger].outinrate * inamount;

            NewMyPayParameters myPayParams = new NewMyPayParameters(_wmidsMap.getJobWmidMap().number, inpurse, outpurse, inamount.ToString(), outamount.ToString());
            return myPayParams;
        }

        /// <summary>
        /// Создать мою новую заявку
        /// </summary>
        /// <param name="listBids"></param>
        /// <returns></returns>
        private ResponseMap createNewMyPay(NewMyPayParameters myPayParams)
        {
            ResponseMap newPay = _exchangerUtils.newPay(myPayParams);

            if (newPay.retval.status == 0)
            {
                logNewPaySuccess(newPay);
            }
            return newPay;
        }

        /// <summary>
        /// Заявка не выставилась на биржу
        /// </summary>
        /// <param name="newPay"></param>
        private void logNewPayFail(ResponseMap newPay)
        {
            StringBuilder logMessage = new StringBuilder("Не удалось поставить заявку");
            logMessage.AppendLine("Причина: " + newPay.retval.status);
            logMessage.AppendLine("Описание: " + newPay.retdesc);
            log.Error(logMessage.ToString());
        }

        /// <summary>
        /// Запись в лог если возникает ошибка добавления нового платежа в бехавиор
        /// </summary>
        /// <param name="err"></param>
        private void logBehaviorErr(String message, String stackTrace, String source)
        {
            StringBuilder logMessage = new StringBuilder("Не могу добавить к обмену заявку.");
            logMessage.AppendLine("Нужно сравнить вручную поставленные заявки, и то что есть в обмене (в хмл файле):");
            logMessage.AppendLine("ошибка: " + message);
            logMessage.AppendLine("StackTrace: " + stackTrace);
            logMessage.AppendLine("источник ошибки: " + source);
            log.Error(logMessage.ToString());
        }

        /// <summary>
        /// Пишем запись в лог, если успешно выставили новый платеж на биржу
        /// </summary>
        /// <param name="newPay"></param>
        private void logNewPaySuccess(ResponseMap newPay)
        {
            StringBuilder logMessage = new StringBuilder("Ставим новую заявку на биржу");
            logMessage.AppendLine("Описание: " + newPay.retdesc);
            logMessage.AppendLine("id заявки" + newPay.retval.operid);
            log.Info(logMessage.ToString());
        }
    }
}