using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ru.xnull.XML;
using ru.xnull.Config.Mapping;
using ru.xnull.GUI;
using log4net;
using ru.xnull.GUI.ConfigUI;
using ru.xnull.GUI.SystemForms;
using ru.xnull.config;

namespace ru.xnull.Config.Initialization
{
    /// <summary>
    /// Класс создает файл конфига из шаблонного xml файла (в основном нужно когда конфига не существует)
    /// </summary>
    public class ConfigTemplater : Handler
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(ConfigTemplater));

        public override Boolean handle()
        {            
            createConfigFileFromTemplateFile();
            successor.setPassword(this.password);
            Boolean result = successor.handle();
            initProxySettings();
            initExternalSettings();
            showConfigCreaterForm();
            return result;            
        }

        /// <summary>
        /// Внешние настройки для бота
        /// </summary>
        private void initExternalSettings()
        {
            ExternalDependencies extSettings = new ExternalDependencies();
            extSettings.ShowDialog();
        }

        private void initProxySettings()
        {
            ProxyInitializer proxyInitForm = new ProxyInitializer();
            proxyInitForm.ShowDialog();
        }

        private void createConfigFileFromTemplateFile()
        {
            log.Info("Создание конфига из шаблона: Берем шаблонный файл конфига и зашифровываем его. Получаем пустой конфиг");
            ConfigCrypter configCrypter = new ConfigCrypter(new Crypter(), this.password);
            XmlDocument configDoc = new XmlDocument();
            configDoc.Load(@"Resources\configTemplate.xml");
            configCrypter.encryptXmlConfigAndSaveToFile(configDoc, ConfigDao.defaultPathToConfig);
        }

        private void showConfigCreaterForm()
        {
            log.Debug("отобразить форму для редактирования конфига");
            ConfigEditorForm creater = new ConfigEditorForm();
            try
            {
                creater.Show();
            }
            catch { }            
        }
    }
}
