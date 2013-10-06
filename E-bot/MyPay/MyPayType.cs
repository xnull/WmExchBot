using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull.MyPay
{
    /// <summary>
    /// Тип запроса - в каком состоянии находится моя заявка
    /// </summary>
    public class MyPayType
    {
        /// <summary>
        /// 0 - вернуть только неоплаченные заявки
        /// </summary>
        public static readonly String NOTPAID = "0";
        /// <summary>
        /// 1 - вернуть оплаченные заявки, но еще не погашенные (по которым еще идет обмен) 
        /// </summary>
        public static readonly String PAID = "1";
        /// <summary>
        /// 2 - вернуть только уже погашенные заявки 
        /// </summary>
        public static readonly String COMPLETED = "2";
        /// <summary>
        /// 3 - вернуть все заявки независимо от сосотояния 
        /// </summary>
        public static readonly String ALL = "3";

        private String currentStatus;

        public MyPayType(String status)
        {
            currentStatus = status;
        }

        public String getStatus()
        {
            return currentStatus;
        }
    }
}
