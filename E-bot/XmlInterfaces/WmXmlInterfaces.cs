using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ru.xnull.NetTools;
using ru.xnull.XML;
using ru.xnull.XmlInterfaces.Request;
using ru.xnull.XmlInterfaces.Response;
using System.Runtime.InteropServices;
using ru.xnull.Config.Mapping;
using log4net;
using ru.xnull.Utils;
using ru.xnull.exchangerapi;

namespace ru.xnull.XmlInterfaces
{
    public class WmXmlInterfaces : IWmXmlInterfaces
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WmXmlInterfaces));
        private INetSender _netSender;

        public WmXmlInterfaces(INetSender netSender)
        {
            _netSender = netSender;
        }
        /// <summary>
        /// Интерфейс X3. Получение истории операций по кошельку. Проверка выполнения операции по переводу средств между кошельками.
        /// http://www.webmoney.ru/rus/developers/interfaces/xml/ophistory/index.shtml
        /// 
        /// Пример юзанья:
        /// X3RequestMap request = new X3RequestMap();
        ///GetOperationsRequestMap getOperations = new GetOperationsRequestMap();
        ///getOperations.purse = purse;
        ///getOperations.datestart = DateStart;
        ///getOperations.datefinish = DateFinish;
        ///request.reqn = 1;
        ///request.wmid = wmid;
        ///request.sign = ExchangerUtils.signString(request.wmid, getOperations.purse + "1");
        /// </summary>
        /// <param name="request">xml запрос</param>
        /// <returns></returns>
        public HistoryMap X3_History(X3RequestMap request)
        {
            log.Debug("Получаем историю операций по кошельку: " + request.getOperations.purse + ". Начало: " + request.getOperations.datestart + ".Конец: " + request.getOperations.datefinish);
            String url = "https://w3s.webmoney.ru/asp/XMLOperations.asp";
            XmlMapper mapper = new XmlMapper();
            String requestString = mapper.classToXmlString<X3RequestMap>(request);

            try
            {
                return mapper.xmlStringToClass<HistoryMap>(_netSender.sendPostData(url, requestString));
            }

            catch (Exception err)
            {
                if (err.Message.Contains("The certificate authority is invalid or incorrect"))
                {
                    log.ErrorFormat("Не установлен корневой сертификат Webmoney. Справка здесь: http://www.webmoney.ru/rus/about/demo/help/common/rootcert.shtml.\nСкачать сертификат можно отсюда: https://www.wmcert.com/Cert/cert.wmtransfer.com_WebMoney%20Transfer%20Root%20Authority.crt.\nУстанавливать сертификат надо в IE.");
                    throw new Exception("Не установлен корневой сертификат Webmoney. Справка здесь: http://www.webmoney.ru/rus/about/demo/help/common/rootcert.shtml.\nСкачать сертификат можно отсюда: https://www.wmcert.com/Cert/cert.wmtransfer.com_WebMoney%20Transfer%20Root%20Authority.crt.\nУстанавливать сертификат надо в IE.");
                }
                log.Error("Ошибка получения истории операций по кошельку: " + request.getOperations.purse, err);
                throw new Exception("Ошибка получения истории операций по кошельку: " + request.getOperations.purse, err);
            }
        }

        /// <summary>
        /// получение списка кошельков, управление которыми доверяет, идентификатор, совершающий запрос
        /// http://wiki.webmoney.ru/wiki/show/%D0%98%D0%BD%D1%82%D0%B5%D1%80%D1%84%D0%B5%D0%B9%D1%81+X15
        /// </summary>
        /// <param name="AuthType"></param>
        /// <returns></returns>
        public string X15_Trust_List(WmidMap wmid)
        {
            try
            {
                string url;
                string query = "<w3s.request><reqn>1</reqn>";
                string plainStr = wmid + "1";
                string signstr;

                signstr = ExchangerUtils.signString(wmid, plainStr);
                url = "https://w3s.webmoney.ru/asp/XMLTrustList.asp";
                query += "<wmid>" + wmid + "</wmid>" +
                         "<sign>" + signstr + "</sign>" +
                         "<gettrustlist>" +
                            "<wmid>" + wmid + "</wmid>" +
                        "</gettrustlist>" +
                     "</w3s.request>";
                return (_netSender.sendPostData(url, query));                
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при получении списков доверия");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wmid"></param>
        /// <param name="purseNumber"></param>
        /// <returns></returns>
        /// <exception cref="BalanceException"></exception>
        public double getBalance(WmidMap wmid, string purseNumber)
        {
            log.Info("Пытаемся получить баланс на кошельке: " + purseNumber);
            double balance = 0;            

            TimeUtils timeUtils = new TimeUtils();
            TimeSpan timeDiff = timeUtils.getDiffWithMoskowTime();
            int diff = (int)timeDiff.TotalHours;

            /* Получить баланс, алгоритм запросов к серваку:
             * прогрессия по часам, то есть делать запрос за предыдущие
             * часы увеличивающиеся в два раза - 1,2,4,8,16,32 ... 2048
             */
            for (int hourse = 1; hourse < Math.Pow(2, 12); hourse = hourse * 2)
            {
                int previvousHourses = hourse / 2;

                String startDateQuery = (DateTime.Now.AddHours(-hourse + 1 - diff)).ToString("yyyyMMdd HH:00:00");
                String finishDateQuery = (DateTime.Now.AddHours(-previvousHourses - diff)).ToString("yyyyMMdd HH:59:59");

                balance = BalanceParser(wmid, purseNumber, startDateQuery, finishDateQuery);
                if (balance != 0)
                {
                    log.Info("Получили баланс на кошельке: " + purseNumber + " - " + balance);
                    return balance;
                }
            }            

            log.Error("Не смогли получить балланс для кошелька: " + purseNumber + ". Для устранения этой проблемы, переведите на кошелек любую сумму. И тогда бот сможет получить баланс");
            throw new BalanceException(purseNumber);
        }

        private double BalanceParser(WmidMap wmid, string purseNumber, string startDateQuery, string finishDateQuery)
        {
            X3RequestMap request = new X3RequestMap();
            GetOperationsRequestMap getOperations = new GetOperationsRequestMap();
            getOperations.purse = purseNumber;
            getOperations.datestart = startDateQuery;
            getOperations.datefinish = finishDateQuery;
            request.reqn = 1;
            request.wmid = wmid.number;
            request.sign = ExchangerUtils.signString(wmid, getOperations.purse + "1");
            if (request.sign == null)
            {
                return 0;
            }

            request.getOperations = getOperations;

            try
            {
                HistoryMap history = X3_History(request);
                if (history.operations.operationsList.Count > 0)
                {
                    String rest = history.operations.operationsList[history.operations.operationsList.Count - 1].rest;
                    Double balance;                    
                    balance = Convert.ToDouble(rest.Replace(".", ","));
                    return balance;
                }
            }
            catch (Exception err)
            {
                log.ErrorFormat("Ошибка при получении баланса кошелька {0}", purseNumber, err);
                return 0;
            }
            return 0;
        }
    }
}
