using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using log4net;

namespace ru.xnull.XML
{
    public class XmlMapper
    {
        private static ILog log = LogManager.GetLogger(typeof(XmlMapper));
        /// <summary>
        /// Сериализовать класс в файл
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="classForSerialize"></param>
        /// <param name="filePath"></param>
        public void save<T>(T classForSerialize, String filePath)
        {
            log.Debug("Сериализовать класс " + classForSerialize.ToString() + " в файл " + filePath);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(File.CreateText(filePath), classForSerialize);
        }

        /// <summary>
        /// сериализовать класс в хмл строку
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="classToSerialize"></param>
        /// <returns></returns>
        public String classToXmlString<T>(T classToSerialize)
        {
            log.Debug("Сериализация класса " + classToSerialize.ToString() + " в строку ");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            xmlSerializer.Serialize(memoryStream, classToSerialize);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;

            UTF8Encoding encoding = new UTF8Encoding();
            String result = encoding.GetString(memoryStream.ToArray());

            return result.Trim();
        }

        public XmlDocument classToXmlDocument<T>(T classToSerialize)
        {
            log.Debug("Сериализация класса " + classToSerialize.ToString() + " в xml документ");
            String xmlString = classToXmlString<T>(classToSerialize);
            XmlDocument result = new XmlDocument();
            result.LoadXml(xmlString);
            return result;
        }

        /// <summary>
        /// Создать из хмл строки - класс
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public T xmlStringToClass<T>(String xmlString)
        {
            log.Debug("Сериализация хмл строки в класс");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            if (xmlString == null)
            {
                log.Error("На вход поступила пустая строка, возращаем null");
                return default(T);
            }

            //log.Debug("Конвертируем xml строку в utf8 кодировку");
            byte[] bytes = Encoding.UTF8.GetBytes(xmlString);
            MemoryStream mem = new MemoryStream(bytes);
            mem.Position = 0;

            T result = default(T);
            try
            {
                result = (T)xmlSerializer.Deserialize(mem);
            }
            catch (Exception err)
            {
                log.Error("Ошибка сериализации хмл строки в класс. Строка:\n" + xmlString, err);
            }
            mem.Close();
            return result;
        }

        public T xmlDocumentToClass<T>(XmlDocument doc)
        {
            log.Debug("Сериализация хмл документа в класс");

            /*
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            MemoryStream mem = new MemoryStream();            
            doc.Save(mem);
            mem.Position = 0;
            T result = (T)xmlSerializer.Deserialize(mem);
            return result;
             */
            return xmlStringToClass<T>(doc.OuterXml);
        }
    }
}
