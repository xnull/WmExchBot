using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
using ru.xnull.NetTools;
using ru.xnull.exchanger;

namespace ru.xnull.Exchanger
{
    /// <summary>
    /// Список заявок выставленных на бирже
    /// </summary>
    public class ListBids : IEnumerable<Bid>
    {
        private List<Bid> _Bids = new List<Bid>();

        public Bid this[int index]
        {
            get
            {
                try
                {
                    return _Bids[index];
                }
                catch
                {
                    return null;
                }
            }
        }

        public int Count
        {
            get { return _Bids.Count; }
        }

        private XmlDocument _ListBidsXmlDoc = new XmlDocument();        

        private int _ExchType;
        public int ExchType
        {
            get { return _ExchType; }
        }

        public int ReverseExchType
        {
            get { return new ExchType().GetReverseExchType(_ExchType); }
        }

        /// <summary>
        /// Возвращает направление обмена. Например WMZ_WMR
        /// </summary>
        public string Direction
        {
            get
            {
                String amountIn = _ListBidsXmlDoc.DocumentElement["WMExchnagerQuerys"].Attributes["amountin"].Value;
                String amountOut = _ListBidsXmlDoc.DocumentElement["WMExchnagerQuerys"].Attributes["amountout"].Value;
                return amountIn + "_" + amountOut;
            }
        }

        public string InPurse_Type
        {
            get { return _ListBidsXmlDoc.DocumentElement["WMExchnagerQuerys"].Attributes["amountin"].Value; }
        }

        public string OutPurse_Type
        {
            get { return _ListBidsXmlDoc.DocumentElement["WMExchnagerQuerys"].Attributes["amountout"].Value; }
        }

        public double OfficalRate
        {
            get { return Convert.ToDouble(_ListBidsXmlDoc.DocumentElement["BankRate"].InnerText); }
        }

        public ListBids(int exchtype, XmlDocument ListBids)
        {
            _ExchType = exchtype;
            _ListBidsXmlDoc = ListBids;
            FillBids(exchtype, ListBids);
        }

        private void FillBids(int exchtype, XmlDocument ListBids)
        {
            foreach (XmlNode currBid in ListBids.DocumentElement["WMExchnagerQuerys"])
            {
                _Bids.Add(new Bid(exchtype, currBid));
            }
        }

        public override string ToString()
        {
            return _ListBidsXmlDoc.OuterXml;
        }




        #region IEnumerable<Bid> Members

        public IEnumerator<Bid> GetEnumerator()
        {
            foreach (Bid currBid in _Bids)
            {
                yield return currBid;
            }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}