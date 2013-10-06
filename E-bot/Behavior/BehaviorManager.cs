using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Config.Mapping.Bot;
using log4net;
using ru.xnull.config;

namespace ru.xnull.Behavior
{
    /// <summary>
    /// Утилитка для работы с бехавиорами
    /// </summary>
    class BehaviorManager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BehaviorManager));
        public BehaviorMap find(String guid)
        {
            log.DebugFormat("Ищем бехавиор {0} в конфиге", guid);
            BehaviorMap finded = findBehaviorInConfig(guid, ConfigDao.Instance().configMap.botMap.behaviors);
            if (finded == null)
            {
                finded = findBehaviorInConfig(guid, ConfigDao.Instance().configMap.archiveMap);
            }
            return finded;
        }

        private BehaviorMap findBehaviorInConfig(String guid, List<BehaviorMap> behaviors)
        {
            foreach (BehaviorMap behavior in behaviors)
            {
                if (behavior.guid.Equals(guid))
                {
                    return behavior;
                }
            }
            return null;
        }
    }
}
