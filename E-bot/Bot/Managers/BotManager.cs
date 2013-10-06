using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using ru.xnull.Config.Mapping.Net;
using ru.xnull.NetTools;
using ru.xnull.Exchanger;
using ru.xnull.Config.Mapping;
using ru.xnull.CentroBank;
using ru.xnull.Threading;
using ru.xnull.Bot;
using ru.xnull.Timers;
using log4net;
using ru.xnull.config;
using ru.xnull.ebot.Bot;

namespace ru.xnull.bot
{
    /// <summary>
    /// Менеджер управляет работой класса Bot.
    /// Запускает в таймере и потоках самого бота, и делает всякие проверки корректности работы и запуска бота
    /// </summary>
    class BotManager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BotManager));
        private ThreadManager threadManager;
        private TimerManager timerManager;

        public BotManager()
        {
            Boter bot = new Boter();
            threadManager = new ThreadManager(bot);
            
            int milliSectimeout = ConfigDao.Instance().configMap.botMap.minutesTimeout * 1000 * 60;
            timerManager = new TimerManager(threadManager, milliSectimeout);
        }               

        public void StartBot()
        {
            log.Debug("Менеджер запускает бота, в отдельном потоке");
            timerManager.startTimer();
        }

        public void StopBot()
        {
            log.Info("Остановка бота");
            timerManager.stopTimer();            
        }
    }
}