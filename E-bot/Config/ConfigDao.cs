using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Security;
using ru.xnull.Config.Mapping;
using ru.xnull.XML;
using ru.xnull.Config;
using log4net;

namespace ru.xnull.config
{
    public class ConfigDao
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ConfigDao));
        //объект синхронизации
        private static object syncLock = new object();
        private static ConfigDao _instance;

        private ConfigMap _configMap;
        private String _configFilePath;

        private ConfigCrypter _configCrypter;
        /// <summary>
        /// путь к файлу конфга, по умолчанию
        /// </summary>
        public static readonly String defaultPathToConfig = Application.StartupPath + "\\e-bot.enc";

        /// <summary>
        /// Класс отображения конфиг файла. 
        /// </summary>
        public ConfigMap configMap
        {
            get { return _configMap; }
        }

        public ConfigCrypter configCrypter
        {
            get { return _configCrypter; }
        }

        public String pathToConfigFile
        {
            get { return _configFilePath; }
        }


        /// <summary>
        /// Синглтон
        /// </summary>
        /// <returns></returns>
        public static ConfigDao Instance()
        {
            if (_instance == null)
            {
                throw new Exception("Вызван метод Instanse() ,без предвариельной инициализации (то есть без вызова метода init())");
            }
            return _instance;
        }

        private static ConfigDao getInstance()
        {
            lock (syncLock)
            {
                if (_instance == null)
                {
                    _instance = new ConfigDao();
                }
            }
            return _instance;
        }

        public static void init(ConfigCrypter configCrypter, String configFilePath)
        {
            getInstance();
            lock (_instance)
            {
                _instance._configFilePath = configFilePath;
                _instance._configCrypter = configCrypter;
                _instance.reloadConfig();
            }
        }

        /// <summary>
        /// Перезагрузить конфиг файл 
        /// </summary>
        public void  reloadConfig()
        {
            if (!File.Exists(_configFilePath))
            {
                throw new ConfigDaoException("Конфиг файл не существует");                
            }
            XmlMapper xmlMapper = new XmlMapper();
            _configMap = xmlMapper.xmlStringToClass<ConfigMap>(_configCrypter.decryptConfigFile(_configFilePath));

            validateConfig();
        }

        /// <summary>
        /// Проверка конфиг файла на корректность
        /// </summary>
        private void validateConfig()
        {
            log.Debug("Проверяем конфиг файл на корректность");
            nullCheckerExceptor(_configMap, "root. Корневой тэг");
            nullCheckerExceptor(_configMap.netMap, "net");
            nullCheckerExceptor(_configMap.wmids, "wmids");
            nullCheckerExceptor(_configMap.botMap, "bot");
            nullCheckerExceptor(_configMap.archiveMap, "archive");
        }

        private void nullCheckerExceptor(Object checkedObject, String checkedObjectName)
        {
            if (checkedObject == null)
            {
                throw new ConfigValidateException(checkedObjectName);                
            }
        }

        /// <summary>
        /// Сохранить и перегрузить конфиг
        /// </summary>
        public void saveAndReloadConfig()
        {
            log.Debug("Сохраняем конфиг и перегружаем его в программу");
            XmlMapper xmlMapper = new XmlMapper();            
            _configCrypter.encryptXmlConfigAndSaveToFile(xmlMapper.classToXmlDocument(_configMap), _configFilePath);
            reloadConfig();
        }

        /// <summary>
        /// Расшифровывет конфиг и выдает его в виде строки
        /// </summary>
        /// <returns></returns>
        public String configToString()
        {
            return _configCrypter.decryptConfigFile(_configFilePath);
        }
    }
}

