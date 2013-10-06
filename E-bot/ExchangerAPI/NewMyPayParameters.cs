using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull.ExchangerAPI
{
    /// <summary>
    /// Класс параметров для создания моего платежа
    /// </summary>
    public class NewMyPayParameters
    {
        private String _wmid;
        private String _inpurse;
        private String _outpurse;
        private String _inamount;
        private String _outamount;

        public NewMyPayParameters(string wmid, string inpurse, string outpurse, string inamount, string outamount)
        {
            _wmid = wmid;
            _inpurse = inpurse;
            _outpurse = outpurse;
            _inamount = inamount;
            _outamount = outamount;
        }

        public String wmid
        {
            get { return _wmid; }
        }

        public String inpurse
        {
            get { return _inpurse; }
        }

        public String outpurse
        {
            get { return _outpurse; }
        }

        public String inamount
        {
            get { return _inamount; }
        }

        public String outamount
        {
            get { return _outamount; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Кошелек источник:" + _inpurse);
            result.AppendLine("Кошелек приемник: " + _outpurse);
            result.AppendLine("Сумма для обмена: " + _inamount);
            result.AppendLine("Желаемая сумма: " + _outamount);

            return result.ToString();
        }
    }
}
