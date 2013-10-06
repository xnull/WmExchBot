using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull.Threading
{
    /// <summary>
    /// Если юзер хочет юзать ThreadManager, то его класс должен реализовывать этот интерфейс 
    /// </summary>
    interface Threaded
    {
        /// <summary>
        /// Код который должен отработать при запуске потока
        /// </summary>
        void start();
    }
}
