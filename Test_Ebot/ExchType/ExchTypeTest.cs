using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Test_Ebot.ExchType
{
    [TestFixture]
    class ExchTypeTest
    {
        [Test]
        public void TestExchType()
        {
            ru.xnull.exchanger.ExchType etype = new ru.xnull.exchanger.ExchType();
            Assert.AreEqual(etype.GetDirectionFromExchType(1), "WMZ_WMR");
            Assert.AreEqual(etype.GetExchTypeFromDirection("WMZ_WMR"), 1);
            Assert.AreEqual(etype.GetReverseDirection("WMZ_WMR"), "WMR_WMZ");
            Assert.AreEqual(etype.GetReverseDirection("WMR_WMZ"), "WMZ_WMR");
            Assert.AreEqual(etype.GetReverseExchType(1), 2);
            Assert.AreEqual(etype.GetReverseExchType(2), 1);

            List<String> directionsList = etype.getDirectionsListFromFullDirection("WMZ_WMR__WMR_WMZ");
            Assert.AreEqual(directionsList.Count, 2);
            Assert.AreEqual(directionsList[0], "WMZ_WMR");
            Assert.AreEqual(directionsList[1], "WMR_WMZ");
        }
    }
}
