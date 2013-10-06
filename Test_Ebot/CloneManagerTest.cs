using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull;
using ru.xnull.Config.Mapping;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.clone;

namespace Test_Ebot
{
    [TestFixture]
    class CloneManagerTest
    {
        [SetUp]
        public void setUp()
        {

        }

        [Test]
        public void checkDeepClone()
        {
            CloneManager cloner = new CloneManager();
                        
            NetMap netMap = new NetMap();
            netMap.tryConnect = 10;
            
            EmailMap email = new EmailMap();
            email.from = "admin@linux.com";
            netMap.emailMap = email;

            NetMap netMapClone = cloner.deepClone<NetMap>(netMap);
            netMapClone.emailMap.from = "admin@microsoft.com";

            Assert.AreEqual(netMap.emailMap.from, "admin@linux.com");
            Assert.AreEqual(netMapClone.emailMap.from, "admin@microsoft.com");
        }

        [Test]
        public void checkMemberwiseClone()
        {
            CloneManager cloner = new CloneManager();

            NetMap netMap = new NetMap();
            netMap.tryConnect = 10;
            Assert.AreEqual(cloner.memberwiseClone<NetMap>(netMap).tryConnect, 10);

        }
    }
}
