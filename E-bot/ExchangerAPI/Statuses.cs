using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull.ExchangerAPI
{
    /// <summary>
    /// Статус заявки
    /// </summary>
    public class Statuses
    {
        public class ChangeKurs_Retval
        {
            /// <summary>
            /// 1 - Заявка которую Вы выбрали для изменения курса не найдена, возможно она уже удалена или полностью погашена.
            /// </summary>
            public static int notFound = 1;
            public static int success = 0;
            /// <summary>
            /// 9 - 
            /// </summary>
            public static int SlishkomChasto = 9;
            public static int boleeChemNa15Procentov = 7;

        }
    }        
}
