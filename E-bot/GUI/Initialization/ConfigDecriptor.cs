using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ru.xnull.XML;
using ru.xnull.Config.Mapping;
using System.IO;
using log4net;
using ru.xnull.GUI;
using ru.xnull.config;

namespace ru.xnull.Config.Initialization
{
    /// <summary>
    /// Класс Берет зашифрованный файл конфига и инициализируется
    /// </summary>
    public class ConfigDecriptor : Handler
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ConfigDecriptor));

        /// <summary>
        /// пытаемся расшифровать конфиг
        /// </summary>
        /// <returns></returns>
        public override Boolean handle()
        {
            ConfigCrypter confCrypter = new ConfigCrypter(new Crypter(), this.password);
            try
            {
                ConfigDao.init(confCrypter, ConfigDao.defaultPathToConfig);
            }
            catch (ConfigCrypterException err)
            {
                ///не верный пароль при расшифровке конфига. 
                ///Надо в начало перейти. как? Пока решил выходить из программы
                MessageBox.Show("Не удалось расшифровать конфиг. Неверный пароль. Попробуйте ещё раз!\\n\n возникшая ошибка:\n" +err.Message);
                return failer.handle();                
            }
            catch (ConfigValidateException err)
            {
                DialogResult userChoise = MessageBox.Show(err.Message + "\n хотите ли вы отредактировать конфиг вручную?", "Ошибка парсинга", MessageBoxButtons.YesNo);
                if (userChoise == DialogResult.Yes)
                {
                    ConfigHandleEditor confHandleEd = new ConfigHandleEditor();
                    confHandleEd.ShowDialog();
                }
                return false;
            }
            return true;
        }
    }
}
