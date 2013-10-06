using System;
using ru.xnull.Exchanger;
using ru.xnull.NetTools;
using log4net;
using ru.xnull.ebot.calc;
using ru.xnull.config;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.ebot.webmoney;
using ru.xnull.ebot.currency;


namespace ru.xnull.calc
{
    public class Convertation
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Convertation));
        private Torgi _torgi;
        private Double wmComiss = 0.008;

        private Double maxWmzComiss = 50;
        private Double maxWmrComiss = 1500;
        private Double maxWmeComiss = 50;

        public static Convertation createConvertation()
        {
            NetMap net = ConfigDao.Instance().configMap.netMap;
            NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
            ListBidsDao lbd = new ListBidsDao(netSender);

            Torgi torgi = new Torgi(lbd);
            Convertation convertation = new Convertation(torgi);
            return convertation;
        }

        public Convertation(Torgi torgi)
        {
            _torgi = torgi;
        }
        /// <summary>
        /// Рассчет выгоды обмена одной валюты на другую. 
        /// Вся необходимая информация об обмене содержится в классе ConvertationInfo,
        /// а именно тип валюты, сумма и её курс.
        /// Итак берем две валюты, чтобы у обоих был курс в одном исчислении.
        /// Например если это курс обмена доллара на рубль и 2-ой рубля на доллар, оба обмена используют
        /// один и тот же курс. Итак курсы WMZ_WMR = 30 рублей, WMR_WMZ = 29 рублей.
        /// Потом берем сумму и получаем максимальную комиссию, сколько в сумме будет(например 30 копеек) - метод getResultComiss
        /// Расчитываем разницу между обоими направлениями и получаем абсолютную выгоду от обмена, например так:
        /// (30 - 0.4) - (29 + 0.4)  = 0.2 рубля с одного бакса
        /// 
        /// </summary>
        /// <param name="convertFirst"></param>
        /// <param name="convertSecond"></param>
        /// <returns></returns>
        public Money X_Y_X(ConvertationInfo convertFirst, ConvertationInfo convertSecond)
        {
            if (convertSecond.rate > convertFirst.rate)
            {
                throw new Exception("Convertation. Ошибка рассчета выгоды с обмена. Проверить правильность поступивших данных");
            }

            double firstResultComiss = getResultComissSumm(convertFirst);
            double secondResultComiss = getResultComissSumm(convertSecond);

            Double result = (convertFirst.rate - firstResultComiss) - (convertSecond.rate + secondResultComiss);
            log.DebugFormat("Курс продажи: {0}, сумма продажи {1}, Курс покупки: {2}, сумма покупки: {3} выгода с обмена: {4}",
                            convertFirst.rate, convertFirst.summ, convertSecond.rate, convertSecond.summ,
                            Trimmer.trimm(result.ToString()));

            return Money.create(convertSecond.currencyName, result);
        }

        private double getResultComissSumm(ConvertationInfo convert)
        {
            Double maxComissSumm = Int32.MaxValue;

            if (convert.wmCurrency == WmCurrency.Wmr)
            {
                maxComissSumm = maxWmrComiss;
            }
            if (convert.wmCurrency == WmCurrency.Wmz)
            {
                maxComissSumm = maxWmzComiss;
            }
            if (convert.wmCurrency == WmCurrency.Wme)
            {
                maxComissSumm = maxWmeComiss;
            }

            Double comissPersent = calcComissionPersent(convert.summ, maxComissSumm);

            return convert.rate * comissPersent;
        }

        /// <summary>
        /// Рассчет суммы комиссии вебмани от суммы.
        /// </summary>
        /// <param name="summ"></param>
        /// <returns></returns>
        private double calcComissionPersent(Double summ, Double maxSummComiss)
        {
            if (summ == 0)
            {
                return wmComiss;
            }

            double summComiss = summ * wmComiss;

            Double resultComissionSumm = Math.Min(summComiss, maxSummComiss);

            if (resultComissionSumm == 0)
            {
                throw new Exception(String.Format("Ошибка расчета комиссии вебмани. Сумма для расчета комиссии: {0}", summ));
            }

            return resultComissionSumm / summ;
        }

        public double Z_R_E_Z(double WMZ_WMR, double WMR_WME, double WME_WMZ)
        {
            //ZREZ= (E/Z - komis) - (Z/R - komiss) / (R/E + komiss)          ;ZRE = (Z/R - komiss) * (R/E + komiss) = Z/E;
            WMZ_WMR = _torgi.rate(WMZ_WMR);
            WMR_WME = _torgi.rate(WMR_WME);
            WME_WMZ = _torgi.rate(WME_WMZ);

            double result = (WME_WMZ - (WME_WMZ * wmComiss)); // E/Z
            result = result - (_torgi.rate((WMZ_WMR - (WMZ_WMR * wmComiss)) / (WMR_WME + (WMR_WME * wmComiss)))); // E/Z - ZRE(Z/E)
            result = result * WMZ_WMR;
            return (result);
        }

        public double Z_E_R_Z(double WMZ_WME, double WME_WMR, double WMR_WMZ)
        {
            //ZERZ =  (Z/E+komis) / (E/R-komis) - (R/Z+komis)    ;ZER = (Z/E+komis) / (E/R-komis) = Z/R            
            WMZ_WME = _torgi.rate(WMZ_WME);
            WME_WMR = _torgi.rate(WME_WMR);
            WMR_WMZ = _torgi.rate(WMR_WMZ);

            double result = (_torgi.rate((WMZ_WME + (WMZ_WME * wmComiss)) / (WME_WMR - (WME_WMR * wmComiss)))); //ZER(Z/R)
            result = result - (WMR_WMZ + (WMR_WMZ * wmComiss));
            return (result);
        }

        public double R_Z_E_R(double WMR_WMZ, double WMZ_WME, double WME_WMR)
        {
            //RZER = (E/R-komis) - (R/Z+komis) * (Z/E+komis)  ;RZE = (R/Z+komis) * (Z/E+komis) = R/E

            WMR_WMZ = _torgi.rate(WMR_WMZ);
            WMZ_WME = _torgi.rate(WMZ_WME);
            WME_WMR = _torgi.rate(WME_WMR);

            double result = (WME_WMR - (WME_WMR * wmComiss)); // E/R
            result = result - ((WMR_WMZ + (WMR_WMZ * wmComiss)) * (WMZ_WME + (WMZ_WME * wmComiss))); // E/R - RZE(R/E)
            return (result);
        }

        public double R_E_Z_R(double WMR_WME, double WME_WMZ, double WMZ_WMR)
        {
            //REZR = (Z/R-komis) - ( (R/E+komis) / (E/Z-komis) )      ;REZ = (R/E+komis) / (E/Z-komis) = R/Z

            WMR_WME = _torgi.rate(WMR_WME);
            WME_WMZ = _torgi.rate(WME_WMZ);
            WMZ_WMR = _torgi.rate(WMZ_WMR);

            double result = (WMZ_WMR - (WMZ_WMR * wmComiss)) - ((WMR_WME + (WMR_WME * wmComiss)) / (WME_WMZ - (WME_WMZ * wmComiss)));
            return (result);
        }

        public double E_Z_R_E(double WME_WMZ, double WMZ_WMR, double WMR_WME)
        {
            //EZRE = (E/Z-komis) * (Z/R-komis) - (R/E+komis)  ;EZR = (E/Z-komis) * (Z/R-komis) = E/R;

            WME_WMZ = _torgi.rate(WME_WMZ);
            WMZ_WMR = _torgi.rate(WMZ_WMR);
            WMR_WME = _torgi.rate(WMR_WME);

            double result = (WME_WMZ - (WME_WMZ * wmComiss)) * (WMZ_WMR - (WMZ_WMR * wmComiss)) - (WMR_WME + (WMR_WME * wmComiss));
            return (result);
        }

        public double E_R_Z_E(double WME_WMR, double WMR_WMZ, double WMZ_WME)
        {
            //E_R_Z_E = ( (E/R-komiss) / (R/Z+komiss) ) - (Z/E+komiss);    E_R_Z = (E/R-komiss) / (R/Z+komis)) = E/Z;

            WMR_WMZ = _torgi.rate(WMR_WMZ);
            WMZ_WME = _torgi.rate(WMZ_WME);
            WME_WMR = _torgi.rate(WME_WMR);

            double result = ((WME_WMR - (WME_WMR * wmComiss)) / (WMR_WMZ + (WMR_WMZ * wmComiss)) - (WMZ_WME + (WMZ_WME * wmComiss)));
            result = result * WMR_WMZ;
            return (result);
        }

    }
}
