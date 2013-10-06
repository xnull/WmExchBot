using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Exchanger;
using System.Xml;
using ru.xnull.NetTools;

using ru.xnull.Config.Mapping.Bot;
using ru.xnull.MyPay;
using ru.xnull.Config.Mapping;
using ru.xnull.CentroBank;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.ebot.Bot.Algorithm;
using log4net;
using ru.xnull.config;
using ru.xnull.exchangerapi;
using ru.xnull.ExchangerAPI;

namespace ru.xnull.ebot.bot
{
    /// <summary>
    /// Класс корректировки позиции моей заявки на бирже
    /// </summary>
    public class MyPayPositionCorrector : Chain
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MyPayPositionCorrector));
        private ListMyPaysDao listMyPaysDao;
        private ConfigMap configMap;

        public MyPayPositionCorrector(ConfigMap configMap, ListMyPaysDao listMyPaysDao)
        {
            this.configMap = configMap;
            this.listMyPaysDao = listMyPaysDao;            
        }

        /// <summary>
        /// Отслеживание заявок и работа с заявками.
        /// </summary>
        /// <exception cref=""></exception>
        public override bool handle()
        {
            log.Debug("Проверяем курсы выставленных заявок и корректируем их при необходимости");
            foreach (BehaviorMap currBehaviour in configMap.botMap.behaviors)
            {
                foreach (BehaviorPayMap currBehaviourPay in currBehaviour.paysMap)
                {
                    MyPayMap MyPay = getMyPayFromSite(currBehaviourPay);
                    
                    if (MyPay.state == MyPayState.Complete)
                    {
                        continue;
                    }

                    if (MyPay.state == MyPayState.Paid)
                    {                        
                        correctMyPositionInExchanger(MyPay, currBehaviourPay);
                    }
                }                
            }
            return successor.handle();
        }

        private void correctMyPositionInExchanger(MyPayMap myPay, BehaviorPayMap behaviourPay)
        {            
            int MyPosition = myPay.GetMyPosition();
            Boolean differenceMyPosition = positionMyPayIsDifference(myPay, behaviourPay);
            if (differenceMyPosition)
            {
                double planKurs;
                int planPosition;
                try
                {
                    planPosition = setRateOrPositionForMyPay(myPay, behaviourPay);
                    planKurs = setPlanRate(behaviourPay, planPosition);
                }
                catch (Exception err)
                {
                   log.Error("Ошибка изменения курса зявки на бирже", err);
                   return;
                }
                changeRate(myPay, behaviourPay, MyPosition, planKurs);
            }
        }

        private MyPayMap getMyPayFromSite(BehaviorPayMap currBehaviourPay)
        {
            MyPayMap MyPay;
            WmidMap wmidOfBehaviorPay = configMap.wmids.getWmid(currBehaviourPay.wmid);
            MyPay = listMyPaysDao.findMyPay(wmidOfBehaviorPay, currBehaviourPay.operid.ToString());
            return MyPay;
        }

        /// <summary>
        /// Если позиция моей заявки отличается от плановой, более чем на 1, то значит произошли изменения на эксченджере и моя заявка сместилась.
        /// </summary>
        /// <param name="myPay"></param>
        /// <param name="currBehaviourPay"></param>
        /// <returns></returns>
        private Boolean positionMyPayIsDifference(MyPayMap myPay, BehaviorPayMap currBehaviourPay)
        {
            int MyPosition = myPay.GetMyPosition();
            int positionResult = MyPosition - currBehaviourPay.currentPlanPosition;
            if (Math.Abs(positionResult) > 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Изменить курс моей заявки (это собственно и есть ожидаемый результат от метода action - изменить курс мей заявки для корректировки положения заявки на бирже)
        /// </summary>
        /// <param name="MyPay"></param>
        /// <param name="currBehaviourPay"></param>
        /// <param name="MyPosition"></param>
        /// <param name="planKurs"></param>
        private void changeRate(MyPayMap MyPay, BehaviorPayMap currBehaviourPay, int MyPosition, double planKurs)
        {
            try
            {
                log.Info("Попытка: Корректируем курс моей заявки: " + MyPay.id + " старый курс заявки: " + MyPay.Rate + " новый курс заявки: " + planKurs);

                double myCurrRate = MyPay.Rate;

                NetMap net = ConfigDao.Instance().configMap.netMap;
                NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
                ExchangerUtils exchangerUtils = new ExchangerUtils(netSender);

                WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(currBehaviourPay.wmid);
                ResponseMap changeRateResult = null;
                if (Math.Abs(myCurrRate - planKurs) > 0.02)
                {
                    changeRateResult = exchangerUtils.changeRate(wmid, currBehaviourPay.operid.ToString(), MyPay.CursType, planKurs.ToString());
                }
                else if (MyPosition == -1)
                {
                    changeRateResult = exchangerUtils.changeRate(wmid, currBehaviourPay.operid.ToString(), MyPay.CursType, planKurs.ToString());
                }

                if (changeRateResult != null & changeRateResult.retval.status == 0)
                {
                    log.Info("Скорректировали курс заявки: " + MyPay.id + " старый курс: " + MyPay.Rate + " новый курс: " + planKurs);
                }
            }
            catch(Exception err)
            {
                log.Debug("Не смог изменить курс заявки", err);
            }
        }

        /// <summary>
        /// Задать плановый курс, который должен быть у заявки
        /// </summary>
        /// <param name="currBehaviourPay"></param>
        /// <param name="planPosition"></param>
        /// <returns></returns>
        private double setPlanRate(BehaviorPayMap currBehaviourPay, int planPosition)
        {
            double planKurs;

            NetMap net = ConfigDao.Instance().configMap.netMap;
            NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
            ListBidsDao listBidsDao = new ListBidsDao(netSender);

            ListBids ListBids = listBidsDao.getListBids(currBehaviourPay.exchType);
            int mesto = planPosition;
            while (true)
            {
                if (Math.Abs(ListBids[planPosition].rate - ListBids[mesto - 2].rate) > 0.03)
                {
                    planKurs = ListBids[mesto].rate;
                    break;
                }
                else
                {
                    mesto = mesto - 2;
                }
            }
            return planKurs;
        }

        private int setRateOrPositionForMyPay(MyPayMap MyPay, BehaviorPayMap currBehaviourPay)
        {
            int planPosition;
            NetMap net = ConfigDao.Instance().configMap.netMap;
            NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
            ListBidsDao listBidsDao = new ListBidsDao(netSender);
            Torgi torgi = new Torgi(listBidsDao);

            planPosition = torgi.setMyPayPosition(MyPay.exchtype, currBehaviourPay.currentPlanPosition, Convert.ToDouble(currBehaviourPay.minRate));
            return planPosition;
        }



        /// <summary>
        /// Послать e-mail уведомление о том что бехавиор разменян
        /// </summary>
        /// <param name="currBehaviour"></param>
        private void sendMailSuccessNotification(DateTime dateExch)
        {
            try
            {
                String subject = "E-bot " + DateTime.Now.ToString("MMdd hh:mm");
                String body = "Обмен выполнен! Дата постановки заявок: " + dateExch.ToString("MMdd hh:mm");
                Mail.Send(subject, body);
            }
            catch { }
        }
    }
}
