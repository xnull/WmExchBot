using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull.MyPay;

namespace Test_Ebot.MyPay
{
    [TestFixture]
    class MyPayTypeTest
    {
        [Test]
        public void checkMyPaType()
        {
            MyPayType myPayType = new MyPayType(MyPayType.ALL);
            Assert.AreEqual(myPayType.getStatus(), "3");
        }
    }
}
