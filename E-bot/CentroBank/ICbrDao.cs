using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.NetTools;
using System.Xml;
using ru.xnull.XML;

namespace ru.xnull.CentroBank
{
    /// <summary>
    /// Класс доступа к объекту CBR
    /// </summary>
    public interface ICbrDao
    {        
        /// <summary>
        /// Получить из сети курсы ЦБ
        /// </summary>
        /// <returns></returns>
        CbrMap getCbr(DateTime date);
        /// <summary>
        /// Получить результирующий урл. Если запрашиваем курсы ЦБ за сегодняшний день, то урл должен быть без указания даты,
        /// чтобы не было ошибки в случае если на компе некорректная дата установлена.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        String getResultUrl(DateTime date);
    }
}
