using NUnit.Framework;
using ru.xnull.calc;
using ru.xnull;
using ru.xnull.ebot.calc;
using ru.xnull.ebot.webmoney;

namespace Test_Ebot.Calc
{
    [TestFixture]
    class ConvertationTest
    {
        [Test]
        public void testCalc()
        {
            Convertation calc = new Convertation(null);

            ConvertationInfo first = new ConvertationInfo();
            first.wmCurrency = WmCurrency.Wmz;
            first.rate = 30;
            first.summ = 1000;

            ConvertationInfo second = new ConvertationInfo();
            second.wmCurrency = WmCurrency.Wmr;
            second.rate = 29;
            second.summ = 1000;

            double result = calc.X_Y_X(first, second).amount;

            Assert.AreEqual(Trimmer.trimm(result.ToString()), "0,52");

            first.summ = 10000;
            result = calc.X_Y_X(first, second).amount;
            Assert.AreEqual(Trimmer.trimm(result.ToString()), "0,61");
        }        
    }
}
