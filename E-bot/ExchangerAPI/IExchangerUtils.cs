using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ru.xnull.Config.Mapping;

namespace ru.xnull.ExchangerAPI
{
    public interface IExchangerUtils
    {
        /// <summary>
        /// Изменить курс заявки
        /// </summary>
        /// <param name="wmid"></param>
        /// <param name="operid"></param>
        /// <param name="curstype">0 - прямой, 1 - обратный </param>
        /// <param name="cursamount"></param>
        /// <returns></returns>
        ResponseMap changeRate(WmidMap wmid, string operid, int curstype, string cursamount);
        
        /// <summary>
        /// Выставить новый платеж на биржу
        /// </summary>
        /// <param name="wmid"></param>
        /// <param name="inpurse"></param>
        /// <param name="outpurse"></param>
        /// <param name="inamount"></param>
        /// <param name="outamount"></param>
        /// <returns></returns>
        ResponseMap newPay(NewMyPayParameters myPayParams);
        /// <summary>
        /// Оплатить лучшую противоположную заявку
        /// </summary>
        /// <param name="wmid"></param>
        /// <param name="isxtrid"></param>
        /// <param name="desttrid"></param>
        /// <returns></returns>
        XmlNode payReflectBestZayavka(WmidMap wmid, string isxtrid, string desttrid);
    }
}
