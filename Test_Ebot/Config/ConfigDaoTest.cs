using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using ru.xnull;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using ru.xnull.config;

namespace Test_Ebot.Config
{
    [TestFixture]
    class ConfigDaoTest
    {
        private Crypter crypter;
        private ConfigCrypter confCrypter;

        [SetUp]
        public void setUp()
        {
            crypter = new Crypter();            
            confCrypter = new ConfigCrypter(crypter, "pass");
        }

        [Test]
        public void checkCorrectInit()
        {
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(@"Resources\Config.xml");
            
            ConfigStub configStub = new ConfigStub();

            File.Delete(Application.StartupPath + "\\e-bot.enc");
            confCrypter.encryptXmlConfigAndSaveToFile(configStub.getXmlDoc(), Application.StartupPath + "\\e-bot.enc");
            
            ConfigDao.init(confCrypter, Application.StartupPath + "\\e-bot.enc");
            Assert.AreEqual(configStub.getXmlDoc().OuterXml, xmlConfig.OuterXml);
            Assert.NotNull(ConfigDao.Instance().configMap);
            Assert.AreEqual(ConfigDao.Instance().configMap.wmids.wmidList.Count, 1);
            Assert.NotNull(ConfigDao.Instance().configMap.netMap.emailMap);
            Assert.NotNull(ConfigDao.Instance().configMap.netMap.proxyMap);
            Assert.NotNull(ConfigDao.Instance().configMap.botMap);
            Assert.AreEqual(ConfigDao.Instance().configMap.archiveMap.Count, 1);

        }
    }
}
