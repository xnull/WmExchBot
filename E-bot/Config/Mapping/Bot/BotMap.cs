using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ru.xnull.Config.Mapping.Bot
{
    [XmlRoot("Bot")]
    public class BotMap
    {
        private bool _job;
        private int _timeout;
        private int _reflectZayavkaTimeout;
        private List<BehaviorMap> _behaviors;

        /// <summary>
        /// Позиция по умолчанию, на которую выставлять заявки, когда создаем "обмен"(бехавиор)
        /// </summary>
        private int _position = 40;

        /// <summary>
        /// Определает продолжать ли работать боту, после размена заявок
        /// </summary>
        [XmlAttribute("job")]
        public bool job
        {
            get { return _job; }
            set { _job = value; }
        }

        /// <summary>
        /// Раз во сколько милли секунд запускать бота.
        /// </summary>
        [XmlAttribute("timeout")]
        public int minutesTimeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        /// <summary>
        /// Раз во сколько секунд проверять, заявки из противоположного направления
        /// если вдруг попадутся заявки с подходящим курсом.
        /// То есть раз во сколько секунд запускать бота мониторящего обратное направление обменов
        /// </summary>
        [XmlAttribute("reflectZayavkaTimeout")]
        public int reflectZayavkaTimeout
        {
            get { return _reflectZayavkaTimeout; }
            set { _reflectZayavkaTimeout = value; }
        }

        [XmlArray("Behaviors")]
        [XmlArrayItem("Behavior")]
        public List<BehaviorMap> behaviors
        {
            get { return _behaviors; }
            set { _behaviors = value; }
        }

        public int position
        {
            get { return _position; }
            set { _position = value; }
        }

    }
}
