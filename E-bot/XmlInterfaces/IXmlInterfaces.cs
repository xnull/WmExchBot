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

namespace ru.xnull.XmlInterfaces
{
    public interface IWmXmlInterfaces
    {        
        /// <summary>
        /// Интерфейс X3. Получение истории операций по кошельку. Проверка выполнения операции по переводу средств между кошельками.
        /// http://www.webmoney.ru/rus/developers/interfaces/xml/ophistory/index.shtml
        /// </summary>
        /// <param name="request">xml запрос</param>
        /// <returns></returns>
        HistoryMap X3_History(X3RequestMap request);

        /// <summary>
        /// получение списка кошельков, управление которыми доверяет, идентификатор, совершающий запрос
        /// http://wiki.webmoney.ru/wiki/show/%D0%98%D0%BD%D1%82%D0%B5%D1%80%D1%84%D0%B5%D0%B9%D1%81+X15
        /// </summary>
        /// <param name="AuthType"></param>
        /// <returns></returns>
        String X15_Trust_List(WmidMap wmid);

        Double getBalance(WmidMap wmid, string purseNumber);
    }
}
