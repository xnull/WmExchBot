using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ru.xnull;
using System.IO;
using System.Windows.Forms;
using ru.xnull.config;

namespace Test_Ebot.Config
{
    /// <summary>
    /// Класс генерирующий заглушки конфигов (так как у меня есть разные методы генерации заглушек и не знаю какой выбрать)
    /// </summary>
    class ConfigStubFactory
    {
        /// <summary>
        /// Создается функциональность реального конфига со всеми методами шифрации сохранения на диск и тд. В общем конфиг как в реальной системе
        /// </summary>
        /// <returns></returns>
        public ConfigDao createConfigHaveRealCrypter()
        {
            Crypter crypter = new Crypter();
            ConfigCrypter confCrypter= new ConfigCrypter(crypter, "password");
            ConfigStub configStub = new ConfigStub();
            File.Delete(Application.StartupPath + "\\e-bot.enc");
            confCrypter.encryptXmlConfigAndSaveToFile(configStub.getXmlDoc(), Application.StartupPath + "\\e-bot.enc");

            ConfigDao.init(confCrypter, Application.StartupPath + "\\e-bot.enc");
            return ConfigDao.Instance();           
        }

        /// <summary>
        /// Создается конфиг с заглушечным шифровщиком, работает только метод для получения хмл документа из конфига
        /// </summary>
        /// <returns></returns>
        public ConfigDao createConfigHaveStubCrypter()
        {
            ConfigStub configStub = new ConfigStub();
            CrypterStub crypterStub = new CrypterStub(configStub.getXmlDoc());
            ConfigCrypter confCrypter = new ConfigCrypter(crypterStub, "password");
            ConfigDao.init(confCrypter, Application.StartupPath + "\\e-bot.enc");
            return ConfigDao.Instance();
        }
    }
}
