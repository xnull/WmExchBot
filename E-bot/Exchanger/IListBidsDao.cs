using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.NetTools;
using System.Xml;


namespace ru.xnull.Exchanger
{
    /// <summary>
    /// Класс для получения заявок с сайта
    /// </summary>
    public interface IListBidsDao
    {
        /// <summary>
        /// Получить список заявок с сайта по определенному направлению обмена
        /// </summary>
        /// <param name="exchType">Направление обмена</param>
        /// <returns></returns>       
        ListBids getListBids(int exchType);
    }
}
