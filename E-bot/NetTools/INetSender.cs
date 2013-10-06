using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net.Mail;
using System.Net;

namespace ru.xnull.NetTools
{
    /// <summary>
    /// Класс для посылки данных по сети
    /// </summary>
    public interface INetSender
    {        
        /// <summary>
        /// Получить данные по протоколу http
        /// </summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        string sendGetData(string url);

        /// <summary>
        /// Пост запросы   
        /// если результат равен null - значит данные не посланы!
        /// </summary>
        /// <param name="url">йцу</param>
        /// <param name="postData"></param>
        /// <returns>"" - данные не посланы!</returns>
        string sendPostData(string url, string postData);
    }
}
