using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Test_Ebot.Config;
using ru.xnull;

namespace Test_Ebot
{
    [TestFixture]
    class PursesFromDirectionTest
    {
        [Test]
        public void checking()
        {
            ConfigStubFactory confStubFactory = new ConfigStubFactory();
            confStubFactory.createConfigHaveRealCrypter();

            PursesFromDirection pfd = new PursesFromDirection("WMR_WMZ__WMZ_WMR");

            Assert.AreEqual(pfd.InPurseType, "WMR");
            Assert.AreEqual(pfd.OutPurseType, "WMZ");

            Assert.AreEqual(pfd.Job_InPurse, "R675010658902");
            Assert.AreEqual(pfd.Job_OutPurse, "Z229563384572");
        }

    }
}
