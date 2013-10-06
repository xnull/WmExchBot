using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace ru.xnull.crypt
{
    public interface IConfigCrypter
    {        
        String password{get;}
        
        /// <summary>
        /// Расшифровать конфиг файл
        /// </summary>
        /// <returns></returns>
        String decryptConfigFile(String configFilePath);

        void encryptXmlConfigAndSaveToFile(XmlDocument newXmlConfig, String configFilePath);

        /// <summary>
        /// Делаем  резервную копию конфиг файла
        /// </summary>
        void createConfigFileBackUp(String configFilePath);

        /// <summary>
        /// Проверить задан ли пароль для конфига
        /// </summary>
        Boolean passwordIsInit();

        string LoadStringFromFile(string FileName);
    }
}
