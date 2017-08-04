using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HBG.Utils
{
    public class XmlHelper
    {
        /// <summary>
        /// 泛型方法 将xml字符串反序列化
        /// </summary>
        /// <typeparam name="T">类型参数</typeparam>
        /// <param name="xmlData">待反序列化xml字符串</param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(string xmlData)
        {
            using (StringReader sr = new StringReader(xmlData))
            {
                //序列化/反序列化对象实例
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                //反序列化
                T model = (T)serializer.Deserialize(sr);

                return model;
            }
        }
        /// <summary>
        /// 对象序列化为xml字符串
        /// </summary>
        /// <typeparam name="T">类型参数</typeparam>
        /// <param name="obj">待序列化对象</param>
        /// <returns></returns>
        public static string XmlSerialize<T>(T obj)
        {
            using (StringWriter sw = new StringWriter())
            {
                Type t = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                sw.Close();
                return sw.ToString();
            }
        }
    }
}
