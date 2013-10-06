using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.NetTools;
using ru.xnull.Exchanger;
using ru.xnull.CentroBank;

using ru.xnull.Config.Mapping.Bot;
using log4net;
using ru.xnull.config;

namespace ru.xnull.behavior
{
    /// <summary>
    /// Класс производит перенос бехавиора в архив
    /// </summary>
    public class BehaviorArchivator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BehaviorArchivator));
        private ConfigDao configDao;

        public BehaviorArchivator(ConfigDao configDao)
        {
            this.configDao = configDao;
        }
        /// <summary>
        /// Заархивировать бехавиоры
        /// </summary>
        /// <param name="BehaviourNumber"></param>
        /// <param name="currBehaviour"></param>
        /// <param name="doArch"></param>
        public void archiveBehavior(String BehaviourNumber)
        {
            /* перенести бехавиор в архив и тэга behavior в archive
             * Найти нужный бехавиор, перенести его в архив
             */
            log.Debug("Архивируем обмен: " + BehaviourNumber);
            BehaviorMap findedBehavior = getBehavior(BehaviourNumber);
            configDao.configMap.botMap.behaviors.Remove(findedBehavior);
            configDao.configMap.archiveMap.Add(findedBehavior);
            configDao.saveAndReloadConfig();

            log.Info("Заархивировали выполненный обмен. Его id: " + findedBehavior.guid);
        }

        private BehaviorMap getBehavior(String BehaviourNumber)
        {
            BotMap bot = configDao.configMap.botMap;
            BehaviorMap findedBeh;

            foreach (BehaviorMap currentBehavior in bot.behaviors)
            {
                if (currentBehavior.guid.Equals(BehaviourNumber))
                {
                    findedBeh = currentBehavior;
                    return findedBeh;
                }
            }
            return null;
        }
    }
}
