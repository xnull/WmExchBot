using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using ru.xnull.bot;

namespace ru.xnull.globalrepo
{
    /// <summary>
    /// Глобадьный репозиторий основных (звездных) классов для программы.
    /// По идее надо будет от этого класса избавиться - но пока
    /// чтобы не плодить стопиццот синглтонов по всей программе, буду использовать
    /// этот репозиторий
    /// </summary>
    class GlobalRepository
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GlobalRepository));
        //объект синхронизации
        private static object syncLock = new object();
        private static GlobalRepository _instance;

        //private ConfigDao configDao;
        private BotManager botManager;

        private static GlobalRepository getInstance()
        {
            lock (syncLock)
            {
                if (_instance == null)
                {
                    _instance = new GlobalRepository();
                }
            }
            return _instance;
        }

        private GlobalRepository()
        {
            botManager = new BotManager();
        }

        /**
        public static ConfigDao getConfigDao(){
            GlobalRepository repo = getInstance();
            if (repo.configDao == null)
            {                
                repo.configDao = ConfigDao.init(;
            }
        }
         */

        public static BotManager getBotManager()
        {
            log.Debug("Получаем BotManager из репозитория");
            return getInstance().botManager;            
        }
    }
}
