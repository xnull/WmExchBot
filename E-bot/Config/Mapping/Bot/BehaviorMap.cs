using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using log4net;
using ru.xnull.exchanger;

namespace ru.xnull.Config.Mapping.Bot
{
    [XmlRoot("Behavior")]
    public class BehaviorMap
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BehaviorMap));

        private String _fullDirections;
        private String _guid;
        private int _planPayCount;
        private List<BehaviorPayMap> _paysMap;

        [XmlAttribute("fullDirection")]
        public String fullDirections
        {
            get { return _fullDirections; }
            set { _fullDirections = value; }
        }

        [XmlAttribute("guid")]
        public String guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        [XmlElement("pay")]
        public List<BehaviorPayMap> paysMap
        {
            get { return _paysMap; }
            set { _paysMap = value; }
        }

        [XmlIgnore]
        public int payCount
        {
            get { return _paysMap.Count; }
        }

        [XmlAttribute("planPayCount")]
        public int planPayCount
        {
            get { return _planPayCount; }
            set { _planPayCount = value; }
        }
                
        /// <summary>
        /// Получить список платежей, которые необходимо выставить по плану на биржу.
        /// То есть тех платежей которых не хватает, для полного бехавиора по плану.
        /// </summary>
        /// <returns></returns>
        public List<string> getMissingPays()
        {
            log.Debug("Получаем список недостающих заявок");
            List<string> MissingPays = new List<string>();
            if (_planPayCount > _paysMap.Count)
            {
                ExchType exchType = new ExchType();
                List<String> planDirections = exchType.getDirectionsListFromFullDirection(_fullDirections);

                foreach (String currentPlanDirection in planDirections)
                {
                    if (!paysMapContainPayForDirection(currentPlanDirection))
                    {
                        log.Info("Найдена недостающая заявка: " + currentPlanDirection);
                        MissingPays.Add(currentPlanDirection);
                    }
                }                    
            }
            return MissingPays;
        }

        public BehaviorPayMap getPayByDirection(String direction)
        {
            foreach (BehaviorPayMap pay in paysMap)
            {
                if (pay.direction.Equals(direction))
                {
                    return pay;
                }
            }
            return null;
        }

        /// <summary>
        /// Проверка есть ли в списке платежей бехавиора, платеж с таким направлением обмена
        /// </summary>
        /// <param name="direction">направление обмена</param>
        /// <returns></returns>
        private bool paysMapContainPayForDirection(String direction)
        {
            log.Debug("Проверка есть ли в списке платежей бехавиора, платеж с таким направлением обмена");
            foreach (BehaviorPayMap currentPay in _paysMap)
            {
                if (currentPay.direction == direction)
                {
                    return true;
                }
            }
            return false;
        }

        public static String generateGuid(){
            return Guid.NewGuid().ToString();
        }

        public String getDateCreate()
        {
            if (_paysMap.Count == 0)
            {
                return null;
            }

            DateTime dateCreate = DateTime.MaxValue;
            foreach (BehaviorPayMap payMap in _paysMap)
            {
                DateTime payDate = DateTime.Parse(payMap.beginDate);
                if (dateCreate > payDate)
                {
                    dateCreate = payDate;
                }
            }
            return dateCreate.ToString("yyyy-MM-dd HH:mm");
        }
    }
}
