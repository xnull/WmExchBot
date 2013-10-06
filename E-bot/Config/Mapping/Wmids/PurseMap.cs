using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ru.xnull.XmlInterfaces;
using ru.xnull.Config.Mapping;
using ru.xnull.NetTools;

namespace ru.xnull.config.mapping
{
    /// <summary>
    /// Кошелек
    /// </summary>
    [XmlRoot("purse")]
    public class PurseMap
    {
        private String _type;
        private String _number;
        private int _summForExch;
        private Double _minSumm;        

        [XmlAttribute("type")]
        public String type
        {
            get { return _type; }
            set { _type = value; }
        }

        [XmlAttribute("number")]
        public String number
        {
            get { return _number; }
            set { _number = value; }
        }

        [XmlAttribute("summForExch")]
        public int summForExch
        {
            get { return _summForExch; }
            set { _summForExch = value; }
        }

        [XmlAttribute("minsumm")]
        public double minSumm
        {
            get { return _minSumm; }
            set { _minSumm = value; }
        }
    }
}
