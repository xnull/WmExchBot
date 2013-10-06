using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using log4net;

namespace ru.xnull.Threading
{
    /// <summary>
    /// Управление потоками
    /// </summary>
    class ThreadManager
    {
        private static ILog log = LogManager.GetLogger(typeof(ThreadManager));

        private Thread thread;
        private ThreadStart threadStart;

        public ThreadManager(Threaded threadObject)
        {
            threadStart = new ThreadStart(threadObject.start);
            thread = new Thread(threadStart);
        }

        public void startThread()
        {
            log.Debug("Запуск нового потока");
            log.Debug("Состояние текущего потока: " + thread.ThreadState);
            if (thread.ThreadState == ThreadState.Stopped)
            {
                thread = new Thread(threadStart);
            }
            try
            {
                thread.Start();
            }
            catch (ThreadStateException err)
            {
                log.Error("Ошибка старта нового потока", err);
            }
        }

        public Boolean joinToThread()
        {
            if (!thread.IsAlive)
            {
                return false;
            }
            log.Debug("Присоединение к потоку");
            thread.Join();
            return true;
        }
    }
}
