using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace ru.xnull.Cache
{
    /// <summary>
    /// Кэш. Хранит объекты помещенные в него, и дату помещения каждого объекта. 
    /// По дате можно определить например актуальность объекта в кэше
    /// </summary>
    public class CacheImpl<K, V>
    {
        private static readonly ILog log = LogManager.GetLogger("ru.xnull.cache.CacheImpl");
        /// <summary>
        /// Список сопоставленных идентификаторов добавленных в кэш объектов, и даты добавления
        /// </summary>
        private Dictionary<K, DateTime> datePutInCache;
        private Dictionary<K, V> cache;

        public CacheImpl()
        {
            datePutInCache = new Dictionary<K, DateTime>();
            cache = new Dictionary<K, V>();
        }

        /// <summary>
        /// Поместить объект в кэш
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void put(K key, V value){
            log.Debug("Поместить объект в кэш");
            if (cache.ContainsKey(key))
            {
                cache.Remove(key);
                datePutInCache.Remove(key);
            }            
            cache.Add(key, value);
            datePutInCache.Add(key, DateTime.Now);
        }

        /// <summary>
        /// Получить объект из кэша
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V getObject(K key)
        {
            log.Debug("Получить объект из кэша");
            return cache[key];
        }

        /// <summary>
        /// Содержит ли кэш объект с интересуемым идентификатором объекта
        /// </summary>
        /// <param name="key">ид объекта</param>
        /// <returns></returns>
        public Boolean contains(K key)
        {
            log.Debug("Определяем Содержит ли кэш объект с интересуемым идентификатором объекта");
            return cache.ContainsKey(key);
        }

        /// <summary>
        /// Дата помещения объекта с данным идентификатором в кэш
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DateTime getDatePutOfObjectInCache(K key)
        {
            log.Debug("Дата помещения объекта с данным идентификатором в кэш " + datePutInCache[key]);
            return datePutInCache[key];
        }
    }
}
