using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull.Config.Mapping.Wmids
{
    class PurseNotFoundException : Exception
    {
        public PurseNotFoundException(string purse) : base("Кошелек" + purse + " не найден") { } 
    }
}
