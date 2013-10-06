using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ru.xnull;
using System.Xml;

namespace Test_Ebot.Config
{
    /// <summary>
    /// Заглушка для возращения хмл содержимого конфига, а не для реальной расшифровки из файла
    /// </summary>
    class CrypterStub : ICrypter
    {
        private XmlDocument _xmlConfig;
        public CrypterStub(XmlDocument config)
        {
            _xmlConfig = config;
        }

        #region ICrypter Members

        public string EncryptString(string data, string password)
        {
            throw new NotImplementedException();
        }

        public string DecryptString(string data, string password)
        {
            return _xmlConfig.OuterXml;
        }

        #endregion
    }
}
