using NUnit.Framework;
using ru.xnull.ebot.currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Ebot.currency
{
    [TestFixture]
    class MoneyTest
    {

        [Test]
        public void testMoneyZero()
        {
            Money m = Money.createRub(0.0000001);
            Assert.AreEqual(m.amount, (int)0);
        }
    }
}
