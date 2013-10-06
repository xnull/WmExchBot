using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.NetTools;
using ru.xnull.Config.Mapping;
using ru.xnull.ExchangerAPI;
using System.Xml;

using ru.xnull.Exchanger;
using ru.xnull.Config.Mapping.Bot;
using ru.xnull.MyPay;
using log4net;
using ru.xnull.config;
using ru.xnull.exchangerapi;

namespace ru.xnull.bot
{
    /// <summary>
    /// Бот ищет противоположные по направлению заявки на бирже к выставленным моим заявкам
    /// и если курс противоположных заявок меня устраивает, то заявка будет куплена
    /// </summary>
    class BotReflect
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BotReflect));
        public void spyTorgi()
        {
            try
            {
                ConfigDao.Instance().reloadConfig();
                NetMap net = ConfigDao.Instance().configMap.netMap;
                NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
                ListMyPaysDao ListMyPaysDao = new ListMyPaysDao(netSender);

                List<BehaviorMap> Behaviours = ConfigDao.Instance().configMap.botMap.behaviors;

                foreach (BehaviorMap currBehaviour in Behaviours)
                {
                    foreach (BehaviorPayMap currPay in currBehaviour.paysMap)
                    {
                        handleCurrPay(netSender, ListMyPaysDao, currPay);
                    }
                }
            }
            catch { }
        }

        private void handleCurrPay(NetSender netSender, ListMyPaysDao ListMyPaysDao, BehaviorPayMap currPay)
        {
            //получить с эксченджера мой платеж (который принадлежит этому бехавиору) 
            WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(currPay.wmid);
            MyPayMap myPay = ListMyPaysDao.findMyPay(wmid, currPay.operid.ToString());

            if (myPay.state == MyPayState.Complete)
            {
                return;
            }

            //если заявка НЕ находится в состоянии - идет обмен, то пропускаем эту заявку
            else if (myPay.state != MyPayState.Paid)
            {
                return;
            }

            //если можно купить чуть дешевле чем продать и это будет выгодно для меня, то купить
            //получаем список заявок в противоположном направлении обмена моей заявке
            ListBidsDao listBidsDao = new ListBidsDao(netSender);
            ListBids ReverseListBids = listBidsDao.getListBids(myPay.GetReverseExchType());

            //курс лучшей заявки в противоположном направлении
            double reflectBestZayavkaRate = ReverseListBids[0].rate;
            //мой минимальный курс который меня удовлетворяет - то есть текущий курс моей заявки
            double minKurs = myPay.Rate;

            if (ReverseListBids.ExchType % 2 == 0)
            {// прямое направление
                if (reflectBestZayavkaRate > minKurs)
                {
                    PayReflectBid(myPay, ReverseListBids);
                }
            }
            else
            {//обратное направление
                if (reflectBestZayavkaRate < minKurs)
                {
                    PayReflectBid(myPay, ReverseListBids);
                }
            }

            return;
        }

        private void PayReflectBid(MyPayMap MyPay, Exchanger.ListBids ReverseListBids)
        {
            NetMap net = ConfigDao.Instance().configMap.netMap;
            NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);

            ExchangerUtils exchangerUtils = new ExchangerUtils(netSender);
            WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(MyPay.wmid);
            ResponseMap changekursResult = exchangerUtils.changeRate(wmid, MyPay.id.ToString(), MyPay.CursType, ReverseListBids[0].rate.ToString());
            XmlNode payReflect = exchangerUtils.payReflectBestZayavka(wmid, MyPay.id.ToString(), ReverseListBids[0].id);

            log.Info("Попытался купить противоположную заявку:\n\n\n" + ReverseListBids[0].BidXmlNode.OuterXml +
                "\n\n\n моя противоположная заявка:\n" + MyPay.ToString() + "\n\nрезультат изменения курса моей заявки:\n\n" +
                changekursResult.retval.status + ": " + changekursResult.retdesc + "\n\nРезультат операции: " +
                payReflect.OuterXml);
        }
    }
}
