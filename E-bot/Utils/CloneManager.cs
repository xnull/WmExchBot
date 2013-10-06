using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Reflection;

namespace ru.xnull.clone
{
    public class CloneManager
    {
        /// <summary>
        /// Поверхностное клонирование. То есть клонируется объект, а все ссылки на другие объекты 
        /// содержащиеся внутри оригинала, переносятся в клонированный объект.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="clonableObject"></param>
        /// <returns></returns>
        public T memberwiseClone<T>(T clonableObject)
        {
            MethodInfo method = clonableObject.GetType().GetMethod("MemberwiseClone", BindingFlags.NonPublic| BindingFlags.Instance);
            return (T)method.Invoke(clonableObject, null);
        }

        /// <summary>
        ///Полная копия объекта.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="clonableObject"></param>
        /// <returns></returns>
        public T deepClone<T>(T clonableObject)
        {
            if (Object.ReferenceEquals(clonableObject, null))
            {                
                return default(T);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            Stream stream = new MemoryStream();
            using (stream)
            {
                serializer.Serialize(stream, clonableObject);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)serializer.Deserialize(stream);
            } 
        }
    }
}
