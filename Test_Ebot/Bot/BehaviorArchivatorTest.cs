using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull;
using Test_Ebot.Config;
using ru.xnull.Config.Mapping.Bot;
using ru.xnull.config;
using ru.xnull.behavior;

namespace Test_Ebot.Bot
{
    [TestFixture]
    class BehaviorArchivatorTest
    {
        [Test]
        public void checkArch()
        {
            ConfigDao configDao = new ConfigStubFactory().createConfigHaveRealCrypter();
            BehaviorArchivator arc = new BehaviorArchivator(configDao);
            
            /* очистить в конфиге бехавиоры
             */
            configDao.configMap.botMap.behaviors.Clear();
            configDao.configMap.archiveMap.Clear();
            configDao.saveAndReloadConfig();
            Assert.AreEqual(configDao.configMap.botMap.behaviors.Count, 0);
            Assert.AreEqual(configDao.configMap.archiveMap.Count, 0);

            /* создать бехавиор
             */
            BehaviorMap savedBehavior = new BehaviorMap();
            savedBehavior.guid = "123";

            /* записать бехавиор в конфиг
             * проверить перенесся ли он в архив, после его архивирования
             */
            configDao.configMap.botMap.behaviors.Add(savedBehavior);            
            configDao.saveAndReloadConfig();
            Assert.AreEqual(configDao.configMap.botMap.behaviors.Count, 1);

            arc.archiveBehavior(savedBehavior.guid);
            Assert.AreEqual(configDao.configMap.botMap.behaviors.Count, 0);
            Assert.AreEqual(configDao.configMap.archiveMap[0].guid, savedBehavior.guid);
        }
    }
}
