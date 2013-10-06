using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Config.Mapping.Bot;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.Exchanger;
using ru.xnull.Config.Mapping;
using log4net;
using ru.xnull.config;

namespace ru.xnull.ebot.Bot.Algorithm
{
    /// <summary>
    /// Задаем для заявки минимальны курс по которому её можно обмениваться на другие заявки
    /// </summary>
    class MinimalRate : Chain
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MinimalRate));
        private Torgi torgi;

        public MinimalRate(Torgi torgi)
        {
            this.torgi = torgi;
        }

        public override bool handle()
        {
            log.Debug("Для всех заявок во всех \"обменах\" в конфиге, задаем минимальный курс продажи");
            List<BehaviorMap> behaviors = ConfigDao.Instance().configMap.botMap.behaviors;

            if(behaviors == null){
                log.Error("Ошибка");
            }

            foreach (BehaviorMap currBehaviour in behaviors)
            {
                int position = ConfigDao.Instance().configMap.botMap.position;

                BehaviorPayMap firstPaysMap = currBehaviour.paysMap[0];
                
                if(behaviors.Count > 1){
                    BehaviorPayMap secondPaysMap = currBehaviour.paysMap[1];
                    setMinRate(secondPaysMap, position, currBehaviour);
                }

                setMinRate(firstPaysMap, position, currBehaviour);

                ConfigDao.Instance().saveAndReloadConfig();
            }
            return true;
        }

        private void setMinRate(BehaviorPayMap myPay, int position, BehaviorMap currBehaviour)
        {
            try
            {
                if (myPay == null)
                {
                    log.ErrorFormat("Обмен {0} не содержит заявки", currBehaviour.guid);
                    return;
                }

                String minRate = torgi.getRateForPosition(myPay.exchType, position).ToString();
                log.InfoFormat("Задаем для заявки {0} минимальный курс по которому её можно обменивать на другие заявки. Курс: {1}, направление обмена {2}", myPay.operid, minRate, myPay.direction);
                
                myPay.currentPlanPosition = 45;
                myPay.minRate = minRate;
            }
            catch (Exception err)
            {
                log.Error("Ошибка при задании минимальной суммы обмена", err);
            }
        }
    }
}
