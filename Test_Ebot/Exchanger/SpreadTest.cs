using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull.Exchanger;

namespace Test_Ebot.Exchanger
{
    [TestFixture]
    class SpreadTest
    {
        [Test]
        public void testSpread()
        {
            Spread spread = new Spread("WMZ_WMR__WMR_WMZ", 10);
            Assert.AreEqual(spread.ForwardDirection, "WMZ_WMR");
            Assert.AreEqual(spread.FullDirection, "WMZ_WMR__WMR_WMZ");
            Assert.AreEqual(spread.ReverseForwardDirection, "WMR_WMZ");
            Assert.AreEqual(spread.spread, 10);
            Assert.AreEqual(spread.GetDirections(), new String[]{"WMZ_WMR", "WMR_WMZ"});
            Assert.AreEqual(spread.GetExchTypes(), new int[]{1,2});
        }
    }
}
