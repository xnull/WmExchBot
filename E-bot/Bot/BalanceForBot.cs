using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using ru.xnull.Config.Mapping.Wmids;
using ru.xnull.Config.Mapping;
using ru.xnull.XmlInterfaces;
using ru.xnull.config.mapping;

namespace ru.xnull.Bot
{
    /// <summary>
    /// Баланс для бота.
    /// Получить баланс, если не получится получить баланс, то выдать сумму для обмена из конфига
    /// </summary>
    class BalanceForBot
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BalanceForBot));
        private IWmXmlInterfaces wmIfaces;

        public BalanceForBot(IWmXmlInterfaces wmIfaces)
        {
            this.wmIfaces = wmIfaces;
        }

        /// <summary>
        /// Получить сумму для обмена, по данному типу кошелька
        /// </summary>
        /// <param name="purseType">тип кошелька</param>
        /// <returns>сумма которую можно выставить на обмен</returns>
        public int getBalance(WmidMap wmidMap, string purseType)
        {
            //log.Debug("Получаем баланс для бота, по типу кошелька: " + purseType);
            PurseMap purse = wmidMap.getPurseByType(purseType);
            if (purse == null)
            {
                throw new PurseNotFoundException(purseType);
            }

            log.Debug("Получить баланс для кошелька: " + purse.number);
            int balance = new int();
            try
            {
                balance = (int)wmIfaces.getBalance(wmidMap, purse.number);
            }
            catch(Exception err)
            {
                log.Debug("Ошибка получения баланса на кошельке", err);
            }

            balance = (int)(balance - (balance * 0.01));
            if (balance == 0)
            {
                log.ErrorFormat("Баланс полученый с кошелька {0}, близок к нулю. Пытаемся выставить сумму по умолчанию: {1}", purse.number, +(int)purse.minSumm);
                balance = (int)purse.minSumm;
            }            

            log.Info("Получили баланс (сумму для обмена) на кошельке " + purseType + ": сумма для обмена: " + balance);

            return balance;
        }
    }
}
