using E_bot.currency;
using ru.xnull.ebot.webmoney;
using System;
using System.Collections.Generic;

namespace ru.xnull.webmoney
{
    public class WmCurrencyNames
    {
        public static readonly int CURR_NAME_LENGTH = 3;

        public static readonly String WMZ = "WMZ";
        public static readonly String WMR = "WMR";
        public static readonly String WME = "WME";
    }

    public class WmCurrencyUtil
    {
        public static WmCurrency fromStr(string wmCurrencyName)
        {
            return (WmCurrency)Enum.Parse(typeof(WmCurrency), wmCurrencyName, true);
        }

        public static String currencyNameFromWm(WmCurrency wmCurr)
        {
            Dictionary<WmCurrency, String> map = new Dictionary<WmCurrency, String>();
            map.Add(WmCurrency.Wmz, CurrencyNames.USD);
            map.Add(WmCurrency.Wmr, CurrencyNames.RUB);
            map.Add(WmCurrency.Wme, CurrencyNames.EUR);

            return map[wmCurr];
        }
    }
}
