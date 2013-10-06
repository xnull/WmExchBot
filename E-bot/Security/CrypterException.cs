using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull
{
    [Serializable()]
    class CrypterException : System.Exception
    {
        public CrypterException() : base() { }
        public CrypterException(string message) : base(message) { }
        public CrypterException(string message, System.Exception inner) : base(message, inner) { }

    }
}
