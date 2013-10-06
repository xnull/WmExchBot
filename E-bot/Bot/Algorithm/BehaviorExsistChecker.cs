using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Config.Mapping.Bot;
using ru.xnull.Config.Mapping;

using log4net;

namespace ru.xnull.ebot.Bot.Algorithm
{
    /// <summary>
    /// Проверка существует ли в конфиге хоть один бехавиор
    /// </summary>
    class BehaviorExsistChecker : Chain
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BehaviorExsistChecker));
        private List<BehaviorMap> behaviors;
        /// <summary>
        /// проверка существует ли в конфиге хоть один бехавиор
        /// </summary>
        public BehaviorExsistChecker(List<BehaviorMap> behaviors)
        {
            this.behaviors = behaviors;
        
        }

        public override bool handle()
        {
            log.Debug("Проверка наличия обменов");
            
            List<BehaviorMap> Behaviours = behaviors;
            if (Behaviours.Count != 0)
            {
                log.Debug("Найдены обмены!");
                return successor.handle();
            }
            log.Info("Обменов не найдено! Cтавим новые заявки на обмен!!! ");
            return failer.handle();
        }
    }
}
