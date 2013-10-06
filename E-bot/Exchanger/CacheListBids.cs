using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ru.xnull.Cache;

namespace ru.xnull.Exchanger
{
    /// <summary>
    /// Кэш списков заявок полученных с сайта
    /// </summary>
    class CacheListBids
    {        
        /// <summary>
        /// Список направлений обменов, в качестве ключа используется exchType
        /// </summary>     
        private CacheImpl<int, ListBids> cacheListBids = new CacheImpl<int, ListBids>();

        public Boolean containsListBids(int exchType)
        {
            return cacheListBids.contains(exchType);
        }

        /// <summary>
        /// Поместить список заявок в кэш, если в кэше уже есть список с данным идентификатором, то это значение обновится
        /// </summary>
        /// <param name="listBids"></param>
        public void put(ListBids listBids)
        {
            cacheListBids.put(listBids.ExchType, listBids);
        }

        public DateTime getDatePutInCache(int exchType)
        {
            return cacheListBids.getDatePutOfObjectInCache(exchType);
        }

        public ListBids get(int exchType)
        {
            return cacheListBids.getObject(exchType);
        }
    }
}
