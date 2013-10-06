using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net.Mail;
using System.Net;

using ru.xnull.Config.Mapping.Net;
using log4net;
using System.Security.Cryptography.X509Certificates;

namespace ru.xnull.NetTools
{
    /// <summary>
    /// Класс для посылки данных по сети
    /// </summary>
    public class NetSender : INetSender
    {
        private static ILog log = LogManager.GetLogger(typeof(NetSender));

        private WebClient _httpClient;
        private ProxyMap proxy;
        private int _tryConnectCount;

        public WebClient getWebClient()
        {
            checkProxy();
            return _httpClient;
        }

        public NetSender(ProxyMap proxy, int tryConnectCount)
        {
            _httpClient = new WebClient();
            //_httpClient.Credentials = new X509Certificate();
            this.proxy = proxy;
            _tryConnectCount = tryConnectCount;
        }
        /// <summary>
        /// Получить данные по протоколу http
        /// </summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public string sendGetData(string url)
        {
            log.Debug("Посылка GET запроса на " + url);
            checkProxy();            
            for (int i = 1; i <= _tryConnectCount; i++)
            {
                try
                {
                    return _httpClient.DownloadString(url);
                }
                catch (Exception err)
                {
                    if (i == _tryConnectCount)
                    {
                        log.Error("Ошибка посылки данных (метод GET) URL: " + url + "\n" + err.Message);
                    }
                }
            }
            return (null);
        }

        /// <summary>
        /// Пост запросы   
        /// если результат равен null - значит данные не посланы!
        /// </summary>
        /// <param name="url">йцу</param>
        /// <param name="postData"></param>
        /// <returns>"" - данные не посланы!</returns>
        public string sendPostData(string url, string postData)
        {
            log.Debug("Посылка POST запроса на " + url);
            checkProxy();
            for (int i = 1; i <= _tryConnectCount; i++)
            {
                try
                {
                    return _httpClient.UploadString(url, "POST", postData);
                }
                catch (Exception err)
                {
                    if (i == _tryConnectCount)
                    {
                        log.Error("Ошибка посылки данных (метод GET) URL: " + url + "\n" + err.Message);
                    }
                }
            }
            log.Error("Ошибка получения данных с сайта. Url " + url);
            return null;
        }

        /// <summary>
        /// Проверка и настройка прокси
        /// </summary>
        private void checkProxy()
        {
            if (proxy.useProxy)
            {
                _httpClient.Proxy = new WebProxy(proxy.ip);
                _httpClient.Proxy.Credentials = new NetworkCredential(proxy.login, proxy.pass);
            }
        }
    }
}