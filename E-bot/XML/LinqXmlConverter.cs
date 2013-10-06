using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using log4net;

namespace ru.xnull.XML
{
    /// <summary>
    /// Преобразователь из Xelement в XmlNode
    /// </summary>
    public class LinqXmlConverter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LinqXmlConverter));
        /// <summary>
        /// Конвертировать XElement в XmlNode
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public XmlNode linqToXml(XElement xElement)
        {
            log.Debug("Конвертируем XElement в XmlNode");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xElement.ToString());
            XmlNode result = xmlDoc.DocumentElement;
            return result;
        }

        public XElement XmlToLinq(XmlNode xmlNode)
        {
            log.Debug("Конвертируем XmlNode в XElement");
            XElement xEl = XElement.Parse(xmlNode.OuterXml);
            return xEl;
        }
    }
}
