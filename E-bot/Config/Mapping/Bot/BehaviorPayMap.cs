using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Linq;
using ru.xnull.XML;
using ru.xnull.exchanger;

namespace ru.xnull.Config.Mapping.Bot
{
    [XmlRoot("pay")]
    public class BehaviorPayMap
    {
        private String _direction;
        private String _wmid;
        private int _operid;
        private int _currentPlanPosition;
        private String _inamount;
        private String _outamount;
        private String _beginDate;
        private String _minRate;

        [XmlAttribute("direction")]
        public String direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        [XmlAttribute("wmid")]
        public String wmid
        {
            get { return _wmid; }
            set { _wmid = value; }
        }

        [XmlAttribute("operid")]
        public int operid
        {
            get { return _operid; }
            set { _operid = value; }
        }

        [XmlAttribute("currentPlanPosition")]
        public int currentPlanPosition
        {
            get { return _currentPlanPosition; }
            set { _currentPlanPosition = value; }
        }

        [XmlAttribute("inamount")]
        public String inamount
        {
            get { return _inamount; }
            set { _inamount = value; }
        }

        [XmlAttribute("outamount")]
        public String outamount
        {
            get { return _outamount; }
            set { _outamount = value; }
        }

        //[XmlAttribute(DataType="time", AttributeName="beginDate")]
        [XmlAttribute("beginDate")]
        public String beginDate
        {
            get { return _beginDate; }
            set { _beginDate = value; }
        }

        [XmlAttribute("minRate")]
        public String minRate
        {
            get { return _minRate; }
            set { _minRate = value.ToString(); }
        }

        [XmlIgnore]
        public int exchType
        {
            get
            {
                ExchType exchType = new ExchType();
                return exchType.GetExchTypeFromDirection(_direction);
            }
        }

        public XElement getXElement()
        {
            XmlMapper xmlMapper = new XmlMapper();
            String thisToString = xmlMapper.classToXmlString<BehaviorPayMap>(this);
            return XElement.Parse(thisToString);
        }
    }
}
