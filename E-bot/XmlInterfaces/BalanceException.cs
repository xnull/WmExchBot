using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull.XmlInterfaces
{
    class BalanceException : Exception
    {
        public BalanceException(String purseNumber)
            : base("Ошибка получения баланса кошелька " + purseNumber){}
        public BalanceException(): base() { }
        //public BalanceException(string message) : base(message) { }
        public BalanceException(string message, System.Exception inner) : base(message, inner) { }
    }
}
