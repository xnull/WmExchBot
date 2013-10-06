using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using log4net;
using ru.xnull.crypt;

namespace ru.xnull.config
{
    public class ConfigCrypter : IConfigCrypter
    {
        private static ILog log = LogManager.GetLogger(typeof(ConfigCrypter));
        /// <summary>
        /// Пароль к конфигу
        /// </summary>
        private String _password;
        private ICrypter _crypter;
    
        public String password
        {
            get { return _password; }
            set { _password = value; }
        }

        public ConfigCrypter(ICrypter crypter, String password)
        {
            _password = password;
            _crypter = crypter;
        }

        /// <summary>
        /// Расшифровать конфиг файл
        /// </summary>
        /// <returns></returns>
        public String decryptConfigFile(String configFilePath)
        {
            if (!passwordIsInit())
            {
                log.Error("Ошибка расшифровки конфига. Пароль для расшифровки конфига не задан");
                throw new ConfigCrypterException("Невозможно расшифровать конфиг файл. Пароль для расшифровки конфига не задан");
            }

            string encryptConfigString = LoadStringFromFile(configFilePath);

            try
            {
                return _crypter.DecryptString(encryptConfigString, _password);
            }
            catch (System.Security.Cryptography.CryptographicException err)
            {
                String errMessage = "Ошибка расшифровки конфиг файла. Неверный пароль.";
                log.Error(errMessage, err);
                throw new ConfigCrypterException(errMessage, err);
            }
        }

        /// <summary>
        /// Зашифровать хмл документ в файл конфига
        /// </summary>
        /// <param name="newXmlConfig"></param>
        /// <param name="configFilePath"></param>
        public void encryptXmlConfigAndSaveToFile(XmlDocument newXmlConfig, String configFilePath)
        {
            if (!passwordIsInit())
            {
                log.Error("Невозможно зашифровать конфиг файл. Пароль для расшифровки конфига не задан");
                throw new ConfigCrypterException("Невозможно зашифровать конфиг файл. Пароль для расшифровки конфига не задан");
            }

            String EncryptConfig = _crypter.EncryptString(newXmlConfig.OuterXml, _password);
            if (EncryptConfig == null)
            {
                String message = "Строка шифра конфиг файла пуста";
                log.Error(message);
                throw new ConfigCrypterException(message);
            }
            try
            {
                File.Delete(configFilePath);
            }
            catch { }
            SaveStringToFile(configFilePath, EncryptConfig);
        }

        /// <summary>
        /// Делаем  резервную копию конфиг файла
        /// </summary>
        public void createConfigFileBackUp(String configFilePath)
        {
            log.Info("Создаем резервную копию конфига: " + "e-bot_backup(" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ").enc");
            File.Copy(configFilePath, Application.StartupPath + "\\e-bot_backup(" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ").enc");
        }

        /// <summary>
        /// Проверить задан ли пароль для конфига
        /// </summary>
        public Boolean passwordIsInit()
        {
            if (_password == null)
            {
                return false;
            }
            return true;
        }

        private void SaveStringToFile(string FileName, string content)
        {
            try
            {
                FileStream file = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                if (file.CanWrite)
                {
                    StreamWriter SW = new StreamWriter(file);
                    SW.WriteLine(content);
                    SW.Flush();
                    SW.Close();
                    file.Close();
                }
            }
            catch (Exception err)
            {
                throw new CrypterException("Ошибка сохранения текста в файл", err);
            }
        }

        public string LoadStringFromFile(string FileName)
        {
            try
            {
                FileStream file = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                if (file.CanRead)
                {
                    StreamReader SR = new StreamReader(file);
                    string result = SR.ReadToEnd();
                    SR.Close();
                    file.Close();
                    return result;
                }
            }
            catch (Exception err)
            {
                throw new CrypterException("Ошибка чтения текста из файла", err);
            }
            return null;
        }
    }
}
