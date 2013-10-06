using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ru.xnull.Exchanger;
using ru.xnull.NetTools;
using System.Xml.Serialization;
using ru.xnull.Config.Mapping.Net;
using log4net;
using ru.xnull.config;
using ru.xnull.exchanger;


namespace ru.xnull.MyPay
{
    /// <summary>
    /// Мой платеж на бирже
    /// </summary>
    [XmlRoot("query")]
    public class MyPayMap
    {
        /// <summary>
        /// <query id="1671988" exchtype="5" state="1" amountin="1" amountout="45,3" 
        ///        inoutrate="0,022" outinrate="45,3" inpurse="E136639439832" outpurse="R675010658902" 
        ///        querydatecr="27.03.2009 5:12:46" querydate="27.03.2009 5:12:46" direction="WME-WMR" /> 
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(typeof(MyPayMap));
        
        private int _id;
        private int _exchtype;
        private int _state;
        private String _amountin;
        private String _amountout;
        private String _inoutrate;
        private String _outinrate;
        private String _inpurse;
        private String _outpurse;
        private String _querydatecr;
        private String _querydate;
        private String _direction;

        private String _wmid;

        [XmlIgnore]
        public String wmid
        {
            get { return _wmid; }
            set { _wmid = value; }
        }



        [XmlAttribute("id")]
        public int id
        {
            get { return _id; }
            set {_id = value;}
        }

        [XmlAttribute("exchtype")]
        public int exchtype
        {
            get { return _exchtype; }
            set { _exchtype = value; }
        }

        [XmlAttribute("state")]
        public int state
        {
            get { return _state; }
            set { _state = value; }
        }

        [XmlAttribute("amountin")]
        public String amountin
        {
            get { return _amountin; }
            set { _amountin = value; }
        }

        [XmlAttribute("amountout")]
        public String amountout
        {
            get { return _amountout; }
            set { _amountout = value; }
        }

        [XmlAttribute("inoutrate")]
        public String inoutrate
        {
            get { return _inoutrate; }
            set { _inoutrate = value; }
        }

        [XmlAttribute("outinrate")]
        public String outinrate
        {
            get { return _outinrate; }
            set { _outinrate = value; }
        }

        [XmlAttribute("inpurse")]
        public String inpurse
        {
            get { return _inpurse; }
            set { _inpurse = value; }
        }

        [XmlAttribute("outpurse")]
        public String outpurse
        {
            get { return _outpurse; }
            set { _outpurse = value; }
        }

        [XmlAttribute("querydatecr")]
        public String querydatecr
        {
            get { return _querydatecr; }
            set { _querydatecr = value; }
        }

        [XmlAttribute("querydate")]
        public String querydate
        {
            get { return _querydate; }
            set { _querydate = value; }
        }

        [XmlAttribute("direction")]
        public String direction
        {
            get { return _direction.Replace("-", "_"); }
            set { _direction = value; }
        }
        
        [XmlIgnore]
        public double Rate
        {
            get
            {
                if (_exchtype % 2 == 0)
                {
                    return Convert.ToDouble(_inoutrate);
                }
                return Convert.ToDouble(_outinrate);                
            }
        }

        /// <summary>
        /// Направление обмена - прямой курс или обратный
        /// </summary>
        [XmlIgnore]
        public int CursType
        {
            get
            {
                if (_exchtype % 2 == 0)
                {
                    return 0;
                }
                return 1;                
            }
        }

        public string GetReverseDirection()
        {
            return (new ExchType().GetReverseDirection(_direction));
        }

        public int GetReverseExchType()
        {
            return (new ExchType().GetReverseExchType(_exchtype));
        }

        public int GetMyPosition()
        {
            log.Debug("Получаем позицю моей заявки " + _id + " на бирже");
            NetMap net = ConfigDao.Instance().configMap.netMap;
            NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
            
            ListBidsDao listBidsDao = new ListBidsDao(netSender);
            Torgi torgi = new Torgi(listBidsDao);
            return torgi.FindMyPosition(_exchtype, _id.ToString());
        }

        public String getMyPositionDescription()
        {
            int result = GetMyPosition();
            if (result == -1)
            {
                return "Заявка не найдена на бирже";
            }
            return result.ToString();
        }

        public override String ToString()
        {
            return "MyPay.id=" + _id;
        }

        /// <summary>
        /// Получить текстовое представление заявки
        /// </summary>
        /// <returns></returns>
        public String getFullInfo()
        {
            StringBuilder result = new StringBuilder();            
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.wmid, _wmid));
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.rate, Rate));
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.inpurse, _inpurse));
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.outpurse, _outpurse));
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.direction, direction));
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.id, _id));

            MyPayState myPayState = new MyPayState();
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.state, myPayState.getState(_state)));
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.amountin, _amountin));
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.amountout, _amountout));
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.inoutrate, _inoutrate));
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.outinrate, _outinrate));            
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.querydatecr, _querydatecr));
            result.AppendLine(String.Format("{0}: {1}", MyPayMapMetaData.querydate, _querydate));

            return result.ToString();
        }
    }
}