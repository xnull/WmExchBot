using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull.config
{
    public class ConfigCrypterException : System.Exception
    {
        public ConfigCrypterException() : base() { }
        public ConfigCrypterException(string message) : base(message) { }
        public ConfigCrypterException(string message, System.Exception inner) : base(message, inner) { }
    }
}
