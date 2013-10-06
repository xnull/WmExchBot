using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using log4net;
using ru.xnull.config;

namespace ru.xnull.BotManagers
{
    /// <summary>
    /// менеджер управляющий ботом следящим за противоположным направлением обмена
    /// </summary>
    class BotReflectManager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BotReflectManager));

        private System.Windows.Forms.Timer reflectTimer = new System.Windows.Forms.Timer();
        private Thread spyReflectThread;

        public BotReflectManager()
        {
            //spyReflectThread = new Thread(new ThreadStart(spyTorgi));
            //reflectTimer.Tick += new EventHandler(reflectTimer_Tick);
        }

        private void reflectTimer_Tick(object sender, EventArgs e)
        {
            reflectTimer.Enabled = false;
            int timeout = 5;
            try
            {
                timeout = ConfigDao.Instance().configMap.botMap.reflectZayavkaTimeout;
            }
            catch (Exception)
            {
                timeout = 2;
            }
            reflectTimer.Interval = 1000 * timeout;
            try
            {
                if (spyReflectThread.IsAlive)
                {
                    spyReflectThread.Join();
                }
                else
                {
                    spyReflectThread = null;
                    //spyReflectThread = new Thread(new ThreadStart(spyTorgi));
                    spyReflectThread.Start();
                }
            }
            catch (Exception err)
            {
               log.Warn("Reflect bot не прошёл!: ", err);
            }
            reflectTimer.Enabled = true;
        }

        public void StartSpyReflectBot()
        {
            reflectTimer.Interval = 1000 * 3;
            reflectTimer.Start();
        }

        public void StopSpyReflectBot()
        {
            reflectTimer.Stop();
            try
            {
                if (spyReflectThread.IsAlive)
                {
                    spyReflectThread.Join();
                }
            }
            catch (Exception) { }

        }
    }
}
