using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull.Config.Initialization
{
    class NotImplementedHandler : Handler
    {
        public override bool handle()
        {
            throw new NotImplementedException("метод не инициализирован");
        }
    }
}
