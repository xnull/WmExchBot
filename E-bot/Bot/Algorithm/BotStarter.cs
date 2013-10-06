using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Config.Mapping;
using ru.xnull.Config.Mapping.Bot;

using ru.xnull.XmlInterfaces;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.NetTools;
using ru.xnull.Exchanger;
using ru.xnull.CentroBank;
using log4net;

namespace ru.xnull.ebot.Bot.Algorithm
{
    /// <summary>
    /// Класс стартующий в самом начале запуска Алгоритма, и запускающий весь алгоритм
    /// </summary>
    public class BotStarter : Chain
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BotStarter));
        private BotMap bot;

        public BotStarter(BotMap botMap)
        {
            bot = botMap;
        }

        /// <summary>
        /// Проверяем в работе ли бот
        /// Если нет поведений в конфиге, то запускаем бота
        /// </summary>
        public override bool handle()
        {
            if (!bot.job)
            {
                log.Info("Не запускаем бота: в конфиге прописано что бот остановлен");
                return false;
            }
            return successor.handle();
        }
    }
}
