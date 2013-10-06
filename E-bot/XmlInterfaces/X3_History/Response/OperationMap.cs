using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ru.xnull.XmlInterfaces.Response
{
    [XmlRoot("operation")]
    public class OperationMap
    {
        private int _id;
        private String _ts;
        private String _pursesrc;
        private String _pursedest;
        private String _amount;
        private String _comiss;
        private String _opertype;
        private String _tranid;
        private String _wminvid;
        private String _orderid;
        private String _period;
        private String _desc;
        private String _datecrt;
        private String _dateupd;
        private String _rest;

        [XmlAttribute("id")]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        [XmlAttribute("ts")]
        public String ts
        {
            get { return _ts; }
            set { _ts = value; }
        }
        
        [XmlElement("pursesrc")]        
        public String pursesrc
        {
            get { return _pursesrc; }
            set { _pursesrc = value; }
        }

        [XmlElement("pursedest")]        
        public String pursedest
        {
            get { return _pursedest; }
            set { _pursedest = value; }
        }

        [XmlElement("amount")]        
        public String amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        [XmlElement("comiss")]        
        public String comiss
        {
            get { return _comiss; }
            set { _comiss = value; }
        }

        [XmlElement("opertype")]       
        public String opertype
        {
            get { return _opertype; }
            set { _opertype = value; }
        }

        [XmlElement("tranid")]        
        public String tranid
        {
            get { return _tranid; }
            set { _tranid = value; }
        }

        [XmlElement("wminvid")]        
        public String wminvid
        {
            get { return _wminvid; }
            set { _wminvid = value; }
        }

        [XmlElement("orderid")]        
        public String orderid
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        [XmlElement("period")]        
        public String period
        {
            get { return _period; }
            set { _period = value; }
        }

        [XmlElement("desc")]
        public String desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        [XmlElement("datecrt")]        
        public String datecrt
        {
            get { return _datecrt; }
            set { _datecrt = value; }
        }

        [XmlElement("dateupd")]        
        public String dateupd
        {
            get { return _dateupd; }
            set { _dateupd = value; }
        }

        [XmlElement("rest")]
        public String rest
        {
            get { return _rest; }
            set { _rest = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Идентификатор: " + _id);
            result.AppendLine("Кошелек отправителя: " + _pursesrc);
            result.AppendLine("Кошелек получателя: " + _pursedest);
            result.AppendLine("Сумма платежа: " + _amount);
            result.AppendLine("Комиссия за выполненный платеж: " + _comiss);
            result.AppendLine("Дата выполнения операции: " + _datecrt);
            result.AppendLine("Дата последнего изменения состояния операции: " + _dateupd);
            result.AppendLine("Описание: " + _desc);
            result.AppendLine("Тип перевода (платежа): " + _opertype);
            result.AppendLine("Номер счета (в системе магазина, выдавшего счет): " + _orderid);
            result.AppendLine("Срок протекции сделки в днях: " + _period);                        
            result.AppendLine("Номер перевода в системе учета отправителя: " + _tranid);
            result.AppendLine("Служебный номер платежа в системе учета WebMoney: " + _ts);
            result.AppendLine("Номер счета (в системе WebMoney): " + _wminvid);
            result.AppendLine("Остаток после выполнения операции: " + _rest);

            return result.ToString();
        }
    }
}
