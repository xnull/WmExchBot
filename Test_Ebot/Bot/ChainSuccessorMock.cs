using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ru.xnull.ebot.Bot.Algorithm;

namespace Test_Ebot.Bot
{
    /// <summary>
    /// Заглушка для цепочки
    /// </summary>
    class ChainSuccessorMock : Chain
    {
        public override bool handle()
        {
            return true;
        }
    }
}
