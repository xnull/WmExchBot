using System;
using System.Collections.Generic;
using System.Collections;
using ru.xnull.calc;
using log4net;
using ru.xnull.ebot.calc;
using ru.xnull.ebot.webmoney;

namespace ru.xnull.Exchanger
{
    /// <summary>
    /// Калькулятор выгоды между обменами. Получает список обменов с биржи и рассчитывает выгоду
    /// и сохраняет результат у себя в списке
    /// </summary>
    class SpreadCalc : IEnumerable
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SpreadCalc));

        private AllExchanges AllExchanges;
        private List<Spread> _Spreads = new List<Spread>();

        public Spread this[int index]
        {
            get { return _Spreads[index]; }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Spread currSpread in _Spreads)
            {
                yield return currSpread;
            }
        }

        public SpreadCalc(IListBidsDao listBidsDao)
        {
            AllExchanges = new AllExchanges(listBidsDao, new int[] { 1, 2, 3, 4, 5, 6 });
            _Spreads.Clear();

            ListBids WMZ_WMR = AllExchanges[0];
            ListBids WMR_WMZ = AllExchanges[1];
            ListBids WMZ_WME = AllExchanges[2];
            ListBids WME_WMZ = AllExchanges[3];
            ListBids WME_WMR = AllExchanges[4];
            ListBids WMR_WME = AllExchanges[5];

            try
            {
                _Spreads.Add(createSpread("WMZ_WMR__WMR_WMZ", WMZ_WMR[1].rate, WmCurrency.Wmz, WMR_WMZ[1].rate, WmCurrency.Wmr));
                //_Spreads.Add(new Spread("WMZ_WME__WME_WMZ", convertation.X_Y_X(WMZ_WME[1].rate, WME_WMZ[1].rate, Currency.Wmz, Currency.Wme) * WME_WMR.OfficalRate));
                _Spreads.Add(createSpread("WME_WMR__WMR_WME", WME_WMR[1].rate, WmCurrency.Wme, WMR_WME[1].rate, WmCurrency.Wmr));
            }
            catch (Exception err)
            {
                log.Debug("Невозможно рассчитать spread", err);
            }
        }

        private Spread createSpread(String fullDirection, Double firstRate, WmCurrency firstCurrency, Double secondRate, WmCurrency secondCurrency)
        {
            Convertation convertation = Convertation.createConvertation();

            ConvertationInfo firstConvert = new ConvertationInfo();
            firstConvert.wmCurrency = firstCurrency;
            firstConvert.rate = firstRate;

            ConvertationInfo secondConvert = new ConvertationInfo();
            secondConvert.wmCurrency = secondCurrency;
            secondConvert.rate = secondRate;

            return new Spread(fullDirection, convertation.X_Y_X(firstConvert, secondConvert).amountRaw);
        }

        public Spread GetSpread(string fulldirection)
        {
            foreach (Spread currSpread in _Spreads)
            {
                if (fulldirection == currSpread.FullDirection)
                {
                    return currSpread;
                }
            }
            return null;
        }
    }


}
