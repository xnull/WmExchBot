using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull.config
{
    public class ConfigDaoException : System.Exception
    {
        public ConfigDaoException() : base() { }
        public ConfigDaoException(string message) : base(message) { }
        public ConfigDaoException(string message, System.Exception inner) : base(message, inner) { }
    }
}
