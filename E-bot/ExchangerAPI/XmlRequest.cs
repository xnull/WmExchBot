using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ru.xnull.ExchangerAPI
{
    /// <summary>
    /// Базовый класс, для создания хмл запросов к бирже (на создание заявок, изменение курсов итд, в общем Api)
    /// </summary>
    public class XmlRequest
    {
        /// <summary>
        /// Результирующий хмл документ, представляющий собой запрос
        /// </summary>
        private XDocument _xmlRequest;
        /// <summary>
        /// Корневой элемент хмл документа
        /// </summary>
        private XElement _root;

        /// <summary>
        /// Инициализируем класс
        /// </summary>
        /// <param name="wmidNumber"></param>
        public XmlRequest(String wmidNumber)
        {
            _xmlRequest = new XDocument();
            _root = new XElement("wm.exchanger.request");
            _xmlRequest.Add(_root);
                        
            _root.Add(new XElement("wmid",wmidNumber));
        }

        /// <summary>
        /// Добавить 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void appendNode(String name, String value)
        {
            XElement node = new XElement(name, value);
            _root.Add(node);
        }        

        /// <summary>
        /// Создать хмл элемент.
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        
        public override String ToString()
        {
            return _xmlRequest.ToString();
        }
    }
}
