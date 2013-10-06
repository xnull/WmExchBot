using System.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using WebMoney.SignerFX;
using ru.xnull.NetTools;
using ru.xnull.ExchangerAPI;

using ru.xnull.XML;
using System.Runtime.InteropServices;
using ru.xnull.Config.Mapping;
using log4net;
using ru.xnull.config;

namespace ru.xnull.exchangerapi
{
    /// <summary>
    /// Класс реализующий функциональность биржи - то есть всё то что прописано в xml интерфейсах эксченджера.
    /// </summary>
    public class ExchangerUtils : IExchangerUtils
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ExchangerUtils));
        private INetSender _netSender;

        public ExchangerUtils(INetSender netSender)
        {
            _netSender = netSender;
        }
        /// <summary>
        /// Изменить курс заявки
        /// </summary>
        /// <param name="wmid"></param>
        /// <param name="operid"></param>
        /// <param name="curstype">0 - прямой, 1 - обратный </param>
        /// <param name="cursamount"></param>
        /// <returns></returns>
        public ResponseMap changeRate(WmidMap wmid, string operid, int curstype, string cursamount)
        {
            log.DebugFormat("Изменяем курс заявки {0} на бирже", operid);
            cursamount = Trimmer.trimm(cursamount);
            string url = "https://wm.exchanger.ru/asp/XMLTransIzm.asp";
            string plainStr, signstr;
            plainStr = wmid + operid + curstype.ToString() + cursamount;
            signstr = signString(wmid, plainStr);

            XmlRequest xmlRequest = new XmlRequest(wmid.number);
            xmlRequest.appendNode("signstr", signstr);
            xmlRequest.appendNode("operid", operid);
            xmlRequest.appendNode("curstype", curstype.ToString());
            xmlRequest.appendNode("cursamount", cursamount);

            try
            {
                XmlMapper xmlMapper = new XmlMapper();
                ResponseMap response = xmlMapper.xmlStringToClass<ResponseMap>(_netSender.sendPostData(url, xmlRequest.ToString()));

                if (response.retval.status == Statuses.ChangeKurs_Retval.success)
                {
                    log.Debug("Выполнено изменение курса заявки: " + operid);
                }
                else if (response.retval.status == Statuses.ChangeKurs_Retval.boleeChemNa15Procentov)
                {
                    //Вы изменили курс заявки более чем на 10-15% (в выгодную для Вас сторону) или более чем на 5% в невыгодную, либо Вы неправильно указали курс, либо Вам необходимо приближаться к требуемому курсу путем нескольких изменений шагами.
                    log.Error("Не удалось выполнить зменение курса заявки, потомучто курс изменился более чем на 10 %:\n ID заявки" + operid + "\n после изменения курс заявки должен был быть равен: " + cursamount);
                }
                else
                {
                    log.Error("Не удалось выполнить изменение курса заявки: " + operid + "\n после изменения курс заявки должен был быть равен: " + cursamount);
                }

                return response;                                                                                                                                    ///<?xml version="1.0"?> <wm.exchanger.response> <retval>1</retval> <retdesc>Заявка которую Вы выбрали для изменения курса не найдена, возможно она уже удалена или полностью погашена.</retdesc></wm.exchanger.response>                     
            }
            catch
            {
                log.ErrorFormat("Не удалось выполнить изменение курса заявки: {0}", operid);
                throw new Exception(String.Format("Не удалось выполнить изменение курса заявки: {0}", operid));
            }
        }

        /// <summary>
        /// Выставить новый платеж на биржу
        /// </summary>
        /// <param name="wmid"></param>
        /// <param name="inpurse"></param>
        /// <param name="outpurse"></param>
        /// <param name="inamount"></param>
        /// <param name="outamount"></param>
        /// <returns></returns>
        public ResponseMap newPay(NewMyPayParameters myPayParams)
        {
            log.Info("Постановка новой заявки на биржу.\n" + myPayParams);
            XmlDocument xmldoc = new XmlDocument();

            String inamount = Trimmer.trimm(myPayParams.inamount);
            String outamount = Trimmer.trimm(myPayParams.outamount);
            string url = "https://wm.exchanger.ru/asp/XMLTrustPay.asp";
            string plainStr, signstr;
            plainStr = myPayParams.wmid + myPayParams.inpurse + myPayParams.outpurse + inamount + outamount;
            WmidMap wmidMap = ConfigDao.Instance().configMap.wmids.getWmid(myPayParams.wmid);
            signstr = signString(wmidMap, plainStr);

            XmlRequest xmlRequest = new XmlRequest(myPayParams.wmid);
            xmlRequest.appendNode("signstr", signstr);
            xmlRequest.appendNode("inpurse", myPayParams.inpurse);
            xmlRequest.appendNode("outpurse", myPayParams.outpurse);
            xmlRequest.appendNode("inamount", inamount);
            xmlRequest.appendNode("outamount", outamount);
            log.DebugFormat("Отправляем запрос на постановку новой заявки: {0}", xmlRequest.ToString());

            try
            {
                XmlMapper mapper = new XmlMapper();
                String receivedData = _netSender.sendPostData(url, xmlRequest.ToString());
                if (receivedData == null)
                {
                    log.ErrorFormat("С сервера получен пустой ответ");
                    return null;
                }
                log.DebugFormat("С сайта получены данные:\n{0}", receivedData);
                ResponseMap response = mapper.xmlStringToClass<ResponseMap>(receivedData);
                log.InfoFormat("Результат постановки новой заявки:\n{0}\nкод: {1},\nid Заявки: {2}", response.retdesc, response.retval.status, response.retval.operid);
                return response;

            }
            catch (Exception err)
            {
                log.Error("Ошибка при постановке новой заявки на биржу. Запрос к серверу\n" + xmlRequest, err);
                throw new Exception("Ошибка при постановке новой заявки на биржу. Запрос к серверу");
            }
        }

        /// <summary>
        /// Оплатить лучшую противоположную заявку
        /// </summary>
        /// <param name="wmid"></param>
        /// <param name="isxtrid"></param>
        /// <param name="desttrid"></param>
        /// <returns></returns>
        public XmlNode payReflectBestZayavka(WmidMap wmid, string isxtrid, string desttrid)
        {
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                string url = "https://wm.exchanger.ru/asp/XMLQrFromTrIns.asp";
                string plainStr, signstr, query;
                plainStr = wmid + isxtrid + desttrid;
                signstr = signString(wmid, plainStr);
                query = "<wm.exchanger.request>" +
                            "<wmid>" + wmid + "</wmid>" +
                            "<signstr>" + signstr + "</signstr>" +
                            "<isxtrid>" + isxtrid + "</isxtrid>" +
                            "<desttrid>" + desttrid + "</desttrid>" +
                        "</wm.exchanger.request>";
                try
                {
                    xmldoc.LoadXml(_netSender.sendPostData(url, query));
                    log.Info("Пытаемся купить противоположную заявку: " + xmldoc.InnerXml + "\n wmid: " + wmid + "\n isxtrid: " + isxtrid + "\n desttrid: " + desttrid);
                    return xmldoc.DocumentElement;
                }
                catch (Exception err)
                {
                    log.Error("Ошибка - не удалость выполнить заявку.", err);
                    throw new Exception("Ошибка - не удалость купить противоположную заявку.");
                }
            }
            catch (Exception)
            {
                return (null);
            }
        }

        public static string signString(WmidMap wmid, string plainStr)
        {
            log.Debug("Подписать строку WmSigner-ом");
            String signStr = null;
            try
            {
                Signer WmSigner = new Signer(wmid.wmKeys);
                signStr = WmSigner.Sign(plainStr, false);
            }
            catch (Exception err)
            {
                log.Error("Обшибка подписи строки WmSigner-ом", err);
            }
            return signStr;
        }
    }
}