using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull.Config.Initialization
{
    /// <summary>
    /// Интерфейс для класса обрабочика в цепочке
    /// цепочка - имеется ввиду chain of resp паттерн
    /// </summary>
    public abstract class Handler
    {
        protected Handler failer;
        protected Handler successor;

        protected String password;

        public void setFailer(Handler failer)
        {
            this.failer = failer;
        }

        public void setSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public void setPassword(String pass)
        {
            password = pass;
        }

        public abstract Boolean handle();
    }
}
