using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ru.xnull.NetTools;
using ru.xnull.CentroBank;
using ru.xnull.GUI;
using System.Xml;
using ru.xnull.XML;
using ru.xnull.Config.Mapping;
using ru.xnull.Config;
using System.Reflection;
using log4net.Config;
using log4net;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.GUI.ConfigUI;
using System.IO;
using ru.xnull.config;

namespace ru.xnull.startup
{
    static class Program
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            initLog4Net();

            log.Info("СТАРТ ПРОГРАММЫ");
            log.Debug("Запскаем визард для конфига");
            ConfigInitWizard confInit = new ConfigInitWizard();
            if (!confInit.run())
            {
                log.Debug("Визард отработал, вернул false - закрываем программу");
                return;
            }
            log.Debug("Визард отработал вернул true - продолжаем работу");

            if (!trialIsExpired())
            {
                new GeneralForm();
                Application.Run();
            }

            log.Info("ЗАВЕРШЕНИЕ РАБОТЫ ПРОГРАММЫ\n");
        }

        /// <summary>
        /// Проверить истекло ли время работы триал версии
        /// </summary>
        /// <returns></returns>
        private static Boolean trialIsExpired()
        {
            log.Debug("Проверяем программу на триальность");

            if (!Trial.isTrialVersion())
            {
                log.Debug("Программа не является триальной");
                return false;
            }
            
            NetMap net = ConfigDao.Instance().configMap.netMap;
            CbrDao cbrDao = new CbrDao(new NetSender(net.proxyMap, net.tryConnect));
            Trial trial = new Trial(cbrDao.getCbr(DateTime.Now), DateTime.Parse("25.03.2011"), false);
            
            Boolean trialExpired = true;
            try
            {
                trialExpired = trial.isExpired();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                DialogResult proxySettings = MessageBox.Show("Возможно Вы используете прокси сервер для соединения с интернетом, хотите ли Вы ввести настройки прокси сервера?", "Настройки прокси", MessageBoxButtons.YesNo);
                if (proxySettings == DialogResult.Yes)
                {
                    ProxyInitializer proxyForm = new ProxyInitializer();
                    proxyForm.ShowDialog();
                    trialIsExpired();
                }
                return true;
            }

            if (trialExpired)
            {
                MessageBox.Show(trial.trialMessage);
                return true;
            }
            return false;

        }

        private static void initLog4Net()
        {
            FileInfo logPropertiesFile = new FileInfo("conf\\log.properties.xml");
            XmlConfigurator.Configure(logPropertiesFile);
        }
    }
}