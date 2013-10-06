using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;

namespace ru.xnull.Exchanger
{
    /// <summary>
    /// Список всех направлений обменов, с содержащимися списками заявок по каждому направлению
    /// </summary>
    class AllExchanges : IEnumerable
    {        
        private List<ListBids> _AllListBids = new List<ListBids>();
        private IListBidsDao _listBidsDao;

        public AllExchanges(IListBidsDao listBidsDao)
        {
            _listBidsDao = listBidsDao;
        }
                
        public AllExchanges(IListBidsDao listBidsDao, int[] exchArray) : this(listBidsDao)
        {
            foreach (int currExch in exchArray)
            {
                _AllListBids.Add(_listBidsDao.getListBids(currExch));
            }
        }

        public ListBids this[int index]
        {
            get { return _AllListBids[index]; }
        }


        public IEnumerator GetEnumerator()
        {
            foreach (ListBids currListBids in _AllListBids)
            {
                yield return currListBids;
            }
        }

        private DateTime _DateCreated = DateTime.Now;
        public DateTime DateCreated
        {
            get { return _DateCreated; }
        }

        

        public ListBids GetListBids(int exchtype)
        {
            foreach (ListBids currListBids in _AllListBids)
            {
                if (exchtype == currListBids.ExchType)
                {
                    return currListBids;
                }
            }
            return null;
        }

        /// <summary>
        /// Получить обмен по имени.
        /// </summary>
        /// <param name="direction">WMZ_WMR например</param>
        /// <returns></returns>
        public ListBids GetListBids(String direction)
        {
            foreach (ListBids currListBids in _AllListBids)
            {
                if (direction == currListBids.Direction)
                {
                    return currListBids;
                }
            }
            return null;
        }

    }
}
