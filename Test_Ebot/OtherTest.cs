using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull.ebot.webmoney;
using ru.xnull.ebot.calc;

namespace Test_Ebot
{
    [TestFixture]
    class OtherTest
    {
        [Test]
        public void testSortedList()
        {
            SortedList<int, String> testCollection = new SortedList<int, string>();
            testCollection.Add(1, "test1");
            testCollection.Remove(1);
            testCollection.Add(1, "test2");
            Assert.AreEqual(testCollection[1], "test2");
        }

        [Test]
        public void testDuble()
        {
            double val = 11.11111111;
            double val2 = 16.234444444444;

            Assert.AreEqual(val.ToString("0"), "11");

            int x = (int)(val + val2);
            Assert.AreEqual(x, 27); 
        }

        [Test]
        public void testEnums()
        {
            WmCurrency curr = WmCurrency.Wmz;
            Assert.NotNull(curr);
        }

        [Test]
        public void testConvertationInfo()
        {
            ConvertationInfo first = new ConvertationInfo();
            first.wmCurrency = WmCurrency.Wmz;

            Assert.AreEqual(first.wmCurrency, WmCurrency.Wmz);
        }

        [Test]
        public void testDouble()
        {
            Double x = 0;
            Assert.AreEqual(x.ToString(), "0");
        }

        [Test]
        public void lambdaSort()
        {
            List<String> list = new List<String>();
            list.Add("2");
            list.Add("1");

            list.Sort((el1, el2) => el1.CompareTo(el2));

            Console.WriteLine(list);
        }
    }
}
