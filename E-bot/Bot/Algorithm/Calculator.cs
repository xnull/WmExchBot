using System;
using ru.xnull.CentroBank;

using ru.xnull.Config.Mapping;
using ru.xnull.XmlInterfaces;
using log4net;
using ru.xnull.config;
using ru.xnull.calc;
using ru.xnull.ebot.calc;
using ru.xnull.webmoney;
using E_bot.currency;
using ru.xnull.Exchanger;
using ru.xnull.exchanger;
using ru.xnull.ebot.webmoney;
using ru.xnull.Bot;

namespace ru.xnull.ebot.Bot.Algorithm
{
    /// <summary>
    /// Калькулятор для рассчета своей стратегии поведения на бирже
    /// </summary>
    public class Calculator : Chain
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Calculator));

        private ICbrDao _cbrDao;
        private WmidMap _wmidMap;
        private IWmXmlInterfaces wmIfaces;

        private IListBidsDao _listBidsDao;

        public Calculator(ICbrDao cbrDAO, WmidMap wmidMap, IWmXmlInterfaces wmIfaces, IListBidsDao listBidsDao)
        {
            _cbrDao = cbrDAO;
            _wmidMap = wmidMap;
            this.wmIfaces = wmIfaces;
            _listBidsDao = listBidsDao;
        }

        /// <summary>
        /// Рассчет сумм для обменов на Бирже, и получение балансов кошельков.
        /// И сохранение в конфиг баллансов и сумм для обмена.
        /// </summary>
        public override Boolean handle()
        {
            log.Debug("Начинаем рассчет сумм для обмена на бирже");
            double usdRate = getOfficalRate(CurrencyNames.USD);
            double eurRate = getOfficalRate(CurrencyNames.EUR);
                        
            int wmrBalance = getBalance(WmCurrencyNames.WMR);
            int wmzBalance = getBalance(WmCurrencyNames.WMZ);

            if (!canCreateBehavior(wmzBalance, wmrBalance))
            {
                log.InfoFormat("Обмен не будет создан, по причине отсутствия выгоды на бирже при постановке заявок");
                return failer.handle();
            }

            saveOfficalRatesAndSummForExchToConfig(usdRate, wmrBalance, wmzBalance);

            return successor.handle();
        }

        /// <summary>
        /// Проверяем есть ли выгода, если мы выставим заявки. Если выгодя нет, то возвращаем 
        /// </summary>
        /// <param name="BehaviourExchanges"></param>
        /// <returns></returns>
        private bool canCreateBehavior(Double wmzBalance, Double wmrBalance)
        {
            log.DebugFormat("Проверяем выгоду от постановки заявки на буржу. Если выгода есть, то даем добро на постановку");

            int payPosition = ConfigDao.Instance().configMap.botMap.position;

            ListBids wmzWmrListBids = _listBidsDao.getListBids(ExchType.EXCH_WMZ_WMR);
            ListBids wmrWmZListBids = _listBidsDao.getListBids(ExchType.EXCH_WMR_WMZ);

            Convertation conv = Convertation.createConvertation();

            ConvertationInfo firstConvert = new ConvertationInfo();
            firstConvert.wmCurrency = WmCurrency.Wmz;
            firstConvert.rate = wmzWmrListBids[payPosition].rate;
            firstConvert.summ = wmzBalance;

            ConvertationInfo second = new ConvertationInfo();
            second.wmCurrency = WmCurrency.Wmr;
            second.rate = wmrWmZListBids[payPosition].rate;
            second.summ = wmrBalance;

            double profit = conv.X_Y_X(firstConvert, second).amount;

            bool haveProfit = profit > 0;
            if (haveProfit)
            {
                log.InfoFormat("Разрешается создать 'обмен' на бирже, профит с одного доллара: {0}", profit);
            }

            return haveProfit;
        }

        /// <summary>
        /// Сохранить официальные курсы валют и суммы для обмена (выставления на биржу) в конфиг
        /// </summary>
        /// <param name="usdRate"></param>
        /// <param name="wmrBalance"></param>
        /// <param name="wmzBalance"></param>
        private void saveOfficalRatesAndSummForExchToConfig(double usdRate, int wmrBalance, int wmzBalance)
        {
            log.Debug("Сохраняем официальные курсы валют и суммы для обмена (выставления на биржу) в конфиг");
            if (((wmrBalance / usdRate) <= wmzBalance))
            {
                int Z_PolovinaOstatka = (int)(wmzBalance - (wmrBalance / usdRate)) / 2;
                int wmzSummForExch = (int)(wmrBalance / usdRate + Z_PolovinaOstatka);

                _wmidMap.getPurseByType(WmCurrencyNames.WMR).summForExch = wmrBalance;
                _wmidMap.getPurseByType(WmCurrencyNames.WMZ).summForExch = wmzSummForExch;
                //_wmidMap.getPurse("WME").summForExch = (int)(wmrBalance / eurRate);

                logBalances(wmrBalance.ToString(), wmzBalance.ToString("0"), wmzBalance.ToString(), wmrBalance.ToString());
            }
            else
            {
                int R_PolovinaOstatka = (int)(wmrBalance - (wmrBalance / usdRate)) / 2;
                int wmrSummForExch = ((int)(wmzBalance * usdRate / 2) + R_PolovinaOstatka);

                _wmidMap.getPurseByType(WmCurrencyNames.WMR).summForExch = wmrSummForExch;
                _wmidMap.getPurseByType(WmCurrencyNames.WMR).summForExch = wmzBalance;
                //_wmidMap.getPurse("WME").summForExch = (int)(wmzBalance * usdRate / eurRate);

                logBalances(wmrBalance.ToString(), wmzBalance.ToString("0"), wmzBalance.ToString(), wmrSummForExch.ToString());
            }
            ConfigDao.Instance().saveAndReloadConfig();
        }

        private void logBalances(String wmrBalance, String wmzBalance, String wmzSummForExch, String wmrSummForExch)
        {
            String message = String.Format("Остатки на кошельках.RUR: {0} USD: {1} \n\nСтавим на обмен. USD: {2} RUR: {3}", wmrBalance.ToString(), wmzBalance, wmzSummForExch, wmrSummForExch);
            log.Info(message);
        }

        /// <summary>
        /// Получить сумму для обмена, по данному типу кошелька
        /// </summary>
        /// <param name="purseType">тип кошелька</param>
        /// <returns>сумма которую можно выставить на обмен</returns>
        private int getBalance(String purseType)
        {
            log.Debug("Получем для бота баланс, для типа кошелька: " + purseType);
            BalanceForBot balancer = new BalanceForBot(wmIfaces);
            int balance = balancer.getBalance(_wmidMap, purseType);            
            
            return balance;
        }

        private double getOfficalRate(String charCode)
        {
            log.Debug("Получаем официальный курс для валюты: " + charCode);
            double rate = 0;
            try
            {
                rate = Convert.ToDouble(_cbrDao.getCbr(DateTime.Now).getCurrency(charCode).rate);
            }
            catch (Exception err)
            {
                log.Debug("ошибка", err);
            }
            return rate;
        }
    }
}
