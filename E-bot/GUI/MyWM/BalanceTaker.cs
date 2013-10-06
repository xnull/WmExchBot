using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Threading;
using ru.xnull.XmlInterfaces;
using ru.xnull.Config.Mapping;
using ru.xnull.NetTools;
using ru.xnull.config;
using log4net;

namespace ru.xnull.GUI.MyWM
{
    /// <summary>
    /// Получение баланса по кошельку в потоке
    /// </summary>
    class BalanceTaker : Threaded
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BalanceTaker));

        private INetSender netSender;
        private String wmidNumber;
        private String purseNumber;
        private String balance;

        public BalanceTaker(INetSender netSender, String wmidNumber, String purseNumber){
            this.netSender = netSender;
            this.wmidNumber = wmidNumber;
            this.purseNumber = purseNumber;
        }

        public void start()
        {
            try
            {
                WmXmlInterfaces xmlInterfaces = new WmXmlInterfaces(netSender);
                WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(wmidNumber);
                balance = xmlInterfaces.getBalance(wmid, purseNumber).ToString();            
            }
            catch (BalanceException err)
            {                
                log.Error("Не удалось получить баланс на кошельке", err);
                balance = String.Format(err.Message);
            }
        }

        public String getBalance()
        {
            return balance;
        }
    }
}
