using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Config.Mapping;

namespace ru.xnull.ebot.Bot.Algorithm
{
    /// <summary>
    /// Интерфейс для класса обрабочика в цепочке
    /// цепочка - имеется ввиду chain of resp паттерн
    /// </summary>
    public abstract class Chain
    {
        protected Chain failer;
        protected Chain successor;
        protected Dictionary<String, Object> parameters = new Dictionary<string, object>();
        
        public void setFailer(Chain failer)
        {
            this.failer = failer;
        }

        public void setSuccessor(Chain successor)
        {
            this.successor = successor;
        }

        public void addParameter(String name, Object parameter)
        {
            parameters.Add(name, parameter);
        }

        public Object getParameter(String name)
        {
            return parameters[name];
        }

        public abstract Boolean handle();
    }
}
