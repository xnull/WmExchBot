using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ru.xnull.Threading;
using log4net;

namespace ru.xnull.Timers
{
    /// <summary>
    /// Класс для удобной работы с таймером
    /// </summary>
    class TimerManager
    {
        private static ILog log = LogManager.GetLogger(typeof(TimerManager));

        private Timer timer;
        ThreadManager threadManager;
        private int milliSecInterval;

        public TimerManager(ThreadManager threadManager, int milliSecInterval)
        {
            this.threadManager = threadManager;
            this.milliSecInterval = milliSecInterval;
        }

        public void startTimer()
        {
            log.Debug("Запускаем таймер");
            timer = new Timer(startOrJoinToThread, null, 0, milliSecInterval);            
        }

        public void stopTimer()
        {
            log.Debug("Останавливаем таймер");
            timer.Dispose();
        }

        public void setInterval(int interval)
        {            
            this.milliSecInterval = interval;
        }

        /// <summary>
        /// Запустить задачу на выполнение или присоединиться к ней
        /// </summary>
        /// <param name="state"></param>
        private void startOrJoinToThread(Object state)
        {
            if (!threadManager.joinToThread())
            {
                threadManager.startThread();                
            }            
        }
    }
}
