using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull;
using System.Collections;
using log4net;
using ru.xnull.webmoney;
using ru.xnull.ebot.webmoney;

namespace ru.xnull.exchanger
{
    public class ExchType
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ExchType));
        private Dictionary<int, String> ExchangeDirections = new Dictionary<int, string>();
        
        
        public static readonly int EXCH_WMZ_WMR = 1;
        public static readonly int EXCH_WMR_WMZ = 2;

        public ExchType()
        {
            ExchangeDirections.Add(EXCH_WMZ_WMR, WmDirectionsNames.WMZ_WMR);
            ExchangeDirections.Add(EXCH_WMR_WMZ, WmDirectionsNames.WMR_WMZ);
            ExchangeDirections.Add(3, "WMZ_WME");
            ExchangeDirections.Add(4, "WME_WMZ");
            ExchangeDirections.Add(5, "WME_WMR");
            ExchangeDirections.Add(6, "WMR_WME");
            ExchangeDirections.Add(25, "WMZ_WMG");
            ExchangeDirections.Add(26, "WMG_WMZ");
            ExchangeDirections.Add(27, "WME_WMG");
            ExchangeDirections.Add(28, "WMG_WME");
            ExchangeDirections.Add(29, "WMR_WMG");
            ExchangeDirections.Add(30, "WMG_WMR");
        }

        public string GetReverseDirection(string direction)
        {
            return direction.Substring(4, 3) + "_" + direction.Substring(0, 3);
        }

        public int GetReverseExchType(int exchtype)
        {
            string Direction = GetDirectionFromExchType(exchtype);
            string ReverseDirection = GetReverseDirection(Direction);
            return GetExchTypeFromDirection(ReverseDirection);
        }

        public int GetExchTypeFromDirection(string direction)
        {
            foreach (KeyValuePair<int, string> currentExchDirect in ExchangeDirections)
            {
                if (currentExchDirect.Value == direction)
                {
                    return currentExchDirect.Key;
                }
            }
            return 0;
        }

        public string GetDirectionFromExchType(int exchtype)
        {
            String direction = null;
            try
            {
                direction = ExchangeDirections[exchtype];
            }
            catch
            {
                log.Error("Для типа направления обмена: " + exchtype + " не существует такого направления обмена");
            }
            return direction;
        }

        public List<string> getAllDirections()
        {
            List<string> result = new List<string>();
            foreach (string currentDirect in ExchangeDirections.Values)
            {
                result.Add(currentDirect);
            }
            return result;
        }

        public List<String> getDirectionsListFromFullDirection(String fullDirection)
        {
            List<String> directions = new List<string>();
            int i = 0;
            while (true)
            {
                if (fullDirection.Length == i+7)
                {
                    directions.Add(fullDirection.Substring(i, 7));
                    break;
                }                
                directions.Add(fullDirection.Substring(i, 7));
                i = i +9;
            }
            return directions;
        }
    }

}