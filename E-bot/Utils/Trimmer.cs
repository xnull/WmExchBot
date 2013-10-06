using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull
{
    /// <summary>
    /// Обрезает число до 3-х знаков
    /// </summary>
    public class Trimmer
    {
        public static String trimm(String sourse)
        {
            string result = checkSource(sourse);
            int pos = sourse.IndexOf(",");

            if (pos <= 0)
            {
                return result;
            }

            pos = pos + 3;
            if (pos > sourse.Length)
            {
                pos = sourse.Length;
            }
            result = sourse.Substring(0, pos);

            return result;
        }

        public static Double trimm(Double sourse, int round)
        {
            return Math.Round(sourse, round); 
        }

        private static string checkSource(String source)
        {
            if (source.Contains("."))
            {
                source = source.Replace(".", ",");
            }
            return source;
        }
    }
}
