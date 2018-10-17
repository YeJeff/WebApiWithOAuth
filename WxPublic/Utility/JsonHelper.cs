using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WxPublic.Utility
{
    public class JsonHelper
    {
        /// <summary>
        /// 将json字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToObject<T>(string json)
        {
            T t = JsonConvert.DeserializeObject<T>(json);
            return t;
        }

        /// <summary>
        /// 将对象序列化为json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            string res = string.Empty;

            JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss.fff";
            jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            res = JsonConvert.SerializeObject(obj, jsonSettings);

            return res;
        }
    }
}