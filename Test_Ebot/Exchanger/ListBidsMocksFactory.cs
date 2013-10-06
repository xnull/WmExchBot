using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ru.xnull.Exchanger;
using System.Xml;

namespace Test_Ebot.Exchanger
{
    class ListBidsMocksFactory
    {

        public ListBids getListBidsStub_exchType1()
        {
            XmlDocument listBidsXmlDoc = new XmlDocument();
            listBidsXmlDoc.Load("Resources\\Exchanger\\ListBids.xml");
            ListBids listBids = new ListBids(1, listBidsXmlDoc);
            return listBids;
        }

        public ListBids getListBidsStub_exchType2()
        {
            XmlDocument listBidsXmlDoc = new XmlDocument();
            listBidsXmlDoc.Load("Resources\\Exchanger\\ListBids_ExchType2.xml");
            ListBids listBids = new ListBids(2, listBidsXmlDoc);
            return listBids;
        }

    }
}
