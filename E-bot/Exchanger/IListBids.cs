using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
using ru.xnull.NetTools;

namespace ru.xnull.Exchanger
{
    /// <summary>
    /// Список заявок выставленных на бирже
    /// </summary>
    public interface IListBids : IEnumerable<Bid>
    {
        void FillBids(int exchtype, XmlDocument ListBids);
        
    }
}