using ru.xnull.ebot.webmoney;
using ru.xnull.webmoney;
using System;
using System.Collections.Generic;

namespace ru.xnull.ebot.calc
{
    public class ConvertationInfo
    {
        /// <summary>
        /// Курс валюты
        /// </summary>
        private Double _rate;

        /// <summary>
        /// Тип валюты
        /// </summary>
        private WmCurrency _currency;

        /// <summary>
        /// Сумма для обмена.
        /// Так как в некоторых случаях нам неважно какая у нас есть сумма для обмена, то она нам не нужна
        /// но рассчитывать то как-то нужно сумму профита, поэтому по дефолту возьмем 1 - я думаю это будет номально
        /// </summary>
        private Double _summ = 1; 

        public Double rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

        public WmCurrency wmCurrency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        public String currencyName
        {
            get { return WmCurrencyUtil.currencyNameFromWm(_currency); }
        }

        public Double summ
        {
            get { return _summ; }
            set { _summ = value; }
        }
    }
}
