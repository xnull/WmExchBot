using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using log4net;
using ru.xnull.config.mapping;

namespace ru.xnull.Config.Mapping
{
    [XmlRoot("wmid")]
    public class WmidMap
    {
        private static ILog log = LogManager.GetLogger(typeof(WmidMap));

        private String _number;
        private String _authType;
        private String _wmKeys;
        private List<PurseMap> _purses;
        
        [XmlAttribute("wmid")]
        public String number
        {
            get { return _number; }
            set { _number = value; }
        }

        [XmlAttribute("AuthType")]
        public String authType
        {
            get { return _authType; }
            set { _authType = value; }
        }
        [XmlAttribute("WMKeys")]
        public String wmKeys
        {
            get { return _wmKeys; }
            set { _wmKeys = value; }
        }


        [XmlElement("purse")] 
        public List<PurseMap> purses
        {
            get { return _purses; }
            set { _purses = value; }
        }

        /// <summary>
        /// Найти кошелек по типу кошелька
        /// </summary>
        /// <param name="purseType"></param>
        /// <returns></returns>
        public PurseMap getPurseByType(string purseType)
        {
            foreach (PurseMap currentPurse in _purses)
            {
                if (currentPurse.type == purseType)
                {
                    return currentPurse;
                }
            }
            log.Warn("Во вмиде нет Типа кошелька " + purseType);
            return null;
        }

        public override string ToString()
        {
            return _number;
        }
    }
}
