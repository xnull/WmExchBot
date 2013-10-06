using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ru.xnull.Exchanger
{
    /// <summary>
    /// Заявка на бирже.
    /// список аявок на бирже https://wm.exchanger.ru/asp/XMLWMList.asp?exchtype=1
    /// 
    /// заявка выглядит так:
    /// <query id="10891679" amountin="82353,04" amountout="2523659,5" inoutrate="0,0326" outinrate="30,6444" procentbankrate="+1,76" allamountin="82353,04" querydate="16.02.2013 16:57:15"/>
    /// </summary>
    public class Bid
    {
        private XmlNode _BidXmlNode;
        public XmlNode BidXmlNode
        {
            get { return _BidXmlNode; }            
        }

        /// <summary>
        /// Направление обмена
        /// </summary>
        private int _exchtype;
        public int exchtype
        {
            get { return _exchtype; }
        }

        /// <summary>
        /// id заявки на бирже
        /// </summary>
        public string id
        {
            get { return _BidXmlNode.Attributes["id"].Value; }
        }

        /// <summary>
        /// тип WM выставленный на обмен. Сумма которую хотят обменять
        /// </summary>
        public double amountin
        {
            get { return Convert.ToDouble(_BidXmlNode.Attributes["amountin"].Value); }
        }

        public double amountout
        {
            get { return Convert.ToDouble(_BidXmlNode.Attributes["amountout"].Value); }
        }

        public double inoutrate
        {
            get { return Convert.ToDouble(_BidXmlNode.Attributes["inoutrate"].Value); }
        }

        public double outinrate
        {
            get { return Convert.ToDouble(_BidXmlNode.Attributes["outinrate"].Value); }
        }

        /// <summary>
        /// Прямой курс обмена
        /// </summary>
        public double rate
        {
            get 
            {
                if (_exchtype % 2 == 0)
                {
                    return inoutrate;
                }
                else
                {
                    return outinrate;
                }                
            }
        }

        public string procentbankrate
        {
            get { return _BidXmlNode.Attributes["procentbankrate"].Value; }
        }

        public string allamountin
        {
            get { return _BidXmlNode.Attributes["allamountin"].Value; }
        }

        public DateTime querydate
        {
            get { return Convert.ToDateTime(_BidXmlNode.Attributes["querydate"].Value); }
        }


        
        public Bid(int exchtype, XmlNode BidXmlNode)
        {
            _exchtype = exchtype;
            _BidXmlNode = BidXmlNode;
        }
    }
}













































//<query id="2246031" amountin="710357,33" amountout="21992,52" inoutrate="32,2999" outinrate="0,0309" procentbankrate="+4,58" allamountin="710357,33" querydate="11.09.2009 7:35:53"/>
