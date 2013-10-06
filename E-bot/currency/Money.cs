using E_bot.currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ru.xnull.ebot.currency
{
    public class Money
    {
        /// <summary>
        /// Имя валюты
        /// </summary>
        private String _currency;

        /// <summary>
        /// Сумма
        /// </summary>
        private Double _amount;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currencyName">CurrencyNames value</param>
        /// <returns></returns>
        public static Money create(String currencyName, Double amount)
        {
            return new Money(currencyName, amount);
        }

        public static Money createUsd(Double amount)
        {
            return new Money(CurrencyNames.USD, amount);
        }

        public static Money createRub(Double amount)
        {
            return new Money(CurrencyNames.RUB, amount);
        }

        private Money(String currency, Double amount)
        {
            _currency = currency;
            _amount = amount;
        }

        public Money add(Money augend)
        {
            checkMoneyType(augend);
            return new Money(_currency, _amount + augend._amount);
        }

        public Money multiply(Double multiplicand)
        {
            return new Money(_currency, _amount * multiplicand);
        }

        public Money subtract(Double substracted)
        {
            return new Money(_currency, _amount / amount);
        }



        private void checkMoneyType(Money money)
        {
            if (!_currency.Equals(money._currency))
            {
                throw new Exception("Нельзя производить арифметические операции над разными типами валют");
            }
        }

        public Double amount
        {
            get { return Trimmer.trimm(_amount, 3); }
        }

        public Double amountRaw
        {
            get { return _amount; }
        }
    }
}
