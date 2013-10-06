using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ru.xnull.Exchanger.XmlMapping
{
    [XmlRoot("query")]
    //<query id="4902843" amountin="1480" amountout="45317,6" inoutrate="0,0326" outinrate="30,62" procentbankrate="+4,33" allamountin="1480" querydate="04.02.2011 5:33:56"></query>
    public class BidMap
    {
        private int _id;
        private String _amountin;
        private String _amountout;
        private String _inoutrate;
        private String _outinrate;
        private String _procentbankrate;
        private String _allamountin;
        private String _querydate;

        [XmlAttribute("id")]
        public int id
        {
            get { return _id; }
            set { _id = value; }
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
        [XmlAttribute("procentbankrate")]
        public String procentbankrate
        {
            get { return _procentbankrate; }
            set { _procentbankrate = value; }
        }
        [XmlAttribute("allamountin")]
        public String allamountin
        {
            get { return _allamountin; }
            set { _allamountin = value; }
        }
        [XmlAttribute("querydate")]
        public String querydate
        {
            get { return _querydate; }
            set { _querydate = value; }
        }

    }
}
