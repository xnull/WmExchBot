using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull
{
    /// <summary>
    /// состояние моей заявки на бирже
    /// </summary>
    public class MyPayState
    {
        private Dictionary<int, String> myPaystate;

        public MyPayState()
        {
            myPaystate = new Dictionary<int, string>();

            myPaystate.Add(0, "Заявка еще не оплачена");
            myPaystate.Add(1, "оплачена, идет обмен");
            myPaystate.Add(2, "погашена полностью");
            myPaystate.Add(3, "объединена с другой новой");
            myPaystate.Add(4, "удалена, средства не возвращены");
            myPaystate.Add(5, "удалена, средства возвращены");
        }

        /// <summary>
        /// заявка еще не оплачена 
        /// </summary>
        public static int NotPaid = 0;
        /// <summary>
        /// оплачена, идет обмен 
        /// </summary>
        public static int Paid = 1;
        /// <summary>
        /// погашена полностью 
        /// </summary>
        public static int Complete = 2;
        /// <summary>
        /// объединена с другой новой 
        /// </summary>
        public static int UnitTo = 3;
        /// <summary>
        /// удалена, средства не возвращены 
        /// </summary>
        public static int DeletedCashNotReseived = 4;
        /// <summary>
        /// удалена, средства возвращены 
        /// </summary>
        public static int DeletedCashReseived = 5;

        public String getState(int cipherState)
        {
            return myPaystate[cipherState];
        }
    }
}