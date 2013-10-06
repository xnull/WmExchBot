using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull;
using System.Xml;
using System.IO;
using Rhino.Mocks;
using System.Windows.Forms;
using ru.xnull.config;

namespace Test_Ebot.Config
{
    [TestFixture]
    class ConfigCrypterTest
    {
        private MockRepository mocks;
        private ICrypter crypterMock;
        private ConfigCrypter confCrypter;        

        [SetUp]
        public void setUp()
        {
            mocks = new MockRepository();
            crypterMock = mocks.DynamicMock<ICrypter>();
            confCrypter = new ConfigCrypter(crypterMock, "pass");
        }

        [Test]
        public void testDecryptConfigFile()
        {
            XmlDocument xmlDocStub = new XmlDocument();
            Expect.Call(crypterMock.EncryptString(xmlDocStub.OuterXml, "pass")).Return("testEncrypt");
            mocks.ReplayAll();

            File.Delete(Application.StartupPath + "\\e-bot.enc");
            confCrypter.encryptXmlConfigAndSaveToFile(xmlDocStub, Application.StartupPath + "\\e-bot.enc");
            Assert.True(File.Exists(Application.StartupPath + "\\e-bot.enc"));

            String resultEncrypt = File.ReadAllText(Application.StartupPath + "\\e-bot.enc").Trim();
            Assert.AreEqual(resultEncrypt, "testEncrypt");
        }

        [Test]
        [ExpectedException(typeof(ConfigCrypterException))]
        public void testForEmptyPassword()
        {
            ConfigCrypter confCrypter = new ConfigCrypter(crypterMock, null);
            confCrypter.decryptConfigFile(Application.StartupPath + "\\e-bot.enc");
        }
    }
}
