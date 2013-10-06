using NUnit.Framework;
using ru.xnull;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Ebot.utils
{
    [TestFixture]
    class TrimmerTest
    {
        [Test]
        public void testTrimm()
        {
            Assert.AreEqual(Trimmer.trimm(2.2231345678, 3), 2.223);
        }
    }
}
