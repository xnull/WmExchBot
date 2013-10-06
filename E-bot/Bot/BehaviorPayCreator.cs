using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Config.Mapping.Bot;

using ru.xnull.Exchanger;
using ru.xnull.ExchangerAPI;
using log4net;

namespace ru.xnull.Bot
{
    /// <summary>
    /// Класс выставляет заявку на биржу, и по этой заявке создает 
    /// платеж в бехавиоре.
    /// ТО есть создает на бирже заявку и маппит результат выставленной заявки на
    /// бехавиор в конфиге
    /// </summary>
    class BehaviorPayCreator
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(BehaviorPayCreator));

        //Добавить новую заявку в конфиг  
        public BehaviorPayMap createBehaviorPay(String wmid, int operId, ListBids listBids, NewMyPayParameters myPayParams)
        {
            log.Info("Сохраняем мою заявку в \"обмен\"");
            BehaviorPayMap behaviorPay = new BehaviorPayMap();
            int positionOnExchanger = 45;
            try
            {
                //Добавить новую заявку в конфиг                                                    
                behaviorPay.wmid = wmid;
                behaviorPay.operid = operId;
                behaviorPay.currentPlanPosition = positionOnExchanger;
                behaviorPay.inamount = myPayParams.inamount;
                behaviorPay.outamount = myPayParams.outamount;
                behaviorPay.beginDate = DateTime.Now.ToString();
                behaviorPay.direction = listBids.Direction;
                behaviorPay.minRate = listBids[positionOnExchanger].rate.ToString();
            }
            catch (Exception err)
            {
                logBehaviorErr(err.Message, err.StackTrace, err.Source);
            }
            return behaviorPay;
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
    }
}
