using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ru.xnull.MyPay
{
    [XmlRoot("WMExchnagerQuerys")]
    public class MyPaysMap
    {
        private List<MyPayMap> _MyPays;

        [XmlElement("query")]
        public List<MyPayMap> listMyPays
        {
            get { return _MyPays; }
            set { _MyPays = value; }
        }

        public MyPayMap getMyPayById(int id)
        {
            foreach (MyPayMap myPay in _MyPays)
            {
                if (myPay.id == id)
                {
                    return myPay;
                }
            }
            return null;
        }
    }
}
