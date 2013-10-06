using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull.Utils
{
    class TimeUtils
    {

        /// <summary>
        /// Получить часовую разницу между локальным временем и московским
        /// </summary>
        /// <returns></returns>
        public TimeSpan getDiffWithMoskowTime()
        {
            TimeSpan moskowTimeOffset = new TimeSpan(4, 0, 0);

            TimeZone localZone = TimeZone.CurrentTimeZone;
            TimeSpan localTimeOffset = localZone.GetUtcOffset(DateTime.Now);

            return localTimeOffset - moskowTimeOffset;
        }
    }
}
