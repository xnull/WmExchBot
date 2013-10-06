using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ru.xnull;
using System.Collections;
using ru.xnull.NetTools;
using ru.xnull.MyPay;
using ru.xnull.Config.Mapping;

using log4net;
using ru.xnull.cache;

namespace ru.xnull
{
    /// <summary>
    /// Список моих заявок на бирже
    /// </summary>
    
    public class ListMyPaysDao
    {
        private static ILog log = LogManager.GetLogger(typeof(ListMyPaysDao));

        private INetSender netSender;
        private CashListMyPays cache;

        public ListMyPaysDao(INetSender netSender)
        {
            this.netSender = netSender;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wmid"></param>
        /// <param name="typeZayavka">тип заявки которую необходимо вернуть</param>
        /// <param name="queryid"></param>
        /// <returns></returns>
        public MyPaysMap getListMyPays(WmidMap wmid, MyPayType myPayType, String queryid)
        {
            cache = new CashListMyPays(netSender);
            return cache.GetListMyPays(wmid, myPayType.getStatus(), queryid.ToString());
        }

        public MyPayMap findMyPay(WmidMap wmid, String queryid)
        {
            log.Debug("Ищем мою заявку " + queryid + " на бирже");
            MyPayType myPayType = new MyPayType(MyPayType.ALL);
            MyPaysMap myPaysMap = getListMyPays(wmid, myPayType, queryid.ToString());
            if (myPaysMap.listMyPays.Count == 0)
            {
                log.Warn("При попытке получения моей заявки (id=" + queryid + ") с биржи произошла ошибка: такой заявки нет на бирже");
                return null;
            }
            return myPaysMap.listMyPays[0];
        }
    }
}
