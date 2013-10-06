using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Config.Mapping;
using ru.xnull.Config.Mapping.Bot;

using ru.xnull.MyPay;
using log4net;
using ru.xnull.behavior;
using ru.xnull.config;

namespace ru.xnull.ebot.Bot.Algorithm
{
    /// <summary>
    /// Проходим по бехавиорам и архивируем выполненные
    /// </summary>
    class BehaviorArchiver : Chain
    {        
        private static readonly ILog log = LogManager.GetLogger(typeof(BehaviorArchiver));
        private ConfigDao configDao;
        private ListMyPaysDao listMyPaysDao;

        public BehaviorArchiver(ConfigDao configDao, ListMyPaysDao listMyPaysDao)
        {
            this.configDao = configDao;
            this.listMyPaysDao = listMyPaysDao;
        }

        public override bool handle()
        {
            log.Debug("Архивируем выполненные заявки, если такие имеются");
            List<BehaviorMap> Behaviours = configDao.configMap.botMap.behaviors;

            List<String> behaviorForArchivate = new List<string>();

            foreach (BehaviorMap currBehaviour in Behaviours)
            {
                bool doArch = true;
                if (currBehaviour.paysMap.Count == 0)
                {
                    return true;
                }
                foreach (BehaviorPayMap currBehaviourPay in currBehaviour.paysMap)
                {
                    //получить мою заявку, проверить статус
                    MyPayMap MyPay = getMyPayFromSite(currBehaviourPay);
                    if (MyPay.state != MyPayState.Complete)
                    {
                        doArch = false;
                    }
                }
                if (doArch)
                {
                    behaviorForArchivate.Add(currBehaviour.guid);                    
                    doArch = false;
                }
            }

            foreach (String behavior in behaviorForArchivate)
            {
                archivateBehavior(behavior);
            }
            return true; 
        }

        private void archivateBehavior(String behaviourGuid)
        {
            log.Info("Архивируем обмен: " + behaviourGuid);
            try
            {
                BehaviorArchivator archivator = new BehaviorArchivator(configDao);
                archivator.archiveBehavior(behaviourGuid);
            }
            catch (Exception err)
            {
                log.Error("Ошибка переноса узла " + behaviourGuid + "в архив.", err);
                Mail.Send("E-bot (" + DateTime.Now.ToString("MMdd hh:mm") + ")", "Обмен заявок выполен! Обмен не заархивировался!");
            }
        }

        private MyPayMap getMyPayFromSite(BehaviorPayMap currBehaviourPay)
        {
            log.Debug("Получить мою заявку " + currBehaviourPay.operid + " с сайта");
            MyPayMap MyPay;
            WmidMap wmidOfBehaviorPay = configDao.configMap.wmids.getWmid(currBehaviourPay.wmid);
            MyPay = listMyPaysDao.findMyPay(wmidOfBehaviorPay, currBehaviourPay.operid.ToString());
            return MyPay;
        }
    }
}
