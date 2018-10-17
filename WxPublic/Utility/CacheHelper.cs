using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Caching;

namespace WxPublic.Utility
{
    public class CacheHelper
    {
        /// <summary>
        /// 从全局缓存中获取指定键对应的缓存对象
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <param name="key">缓存键名</param>
        /// <returns>缓存中指定键名的对象</returns>
        public static T GetCache<T>(string key)
        {
            T obj = (T)HttpRuntime.Cache.Get(key);
            return obj;
        }

        /// <summary>
        /// 从全局缓存中移除指定键名的缓存
        /// </summary>
        /// <typeparam name="T">已移除缓存对象的类型</typeparam>
        /// <param name="key">缓存键名</param>
        /// <returns>已从缓存中移除的对象</returns>
        public static T RemoveCache<T>(string key)
        {
            T obj = (T)HttpRuntime.Cache.Remove(key);
            return obj;
        }

        /// <summary>
        /// 更新或插入缓存
        /// </summary>
        /// <typeparam name="T">插入及返回的缓存对象的类型</typeparam>
        /// <param name="key">缓存键名</param>
        /// <param name="obj">将要插入缓存的对象</param>
        /// <param name="expire_seconds">缓存过期时间（s）</param>
        public static void UpdateOrSetCache<T>(string key, T obj, long expire_seconds)
        {
            try
            {
                HttpRuntime.Cache.Insert(key, obj, null, DateTime.Now.AddSeconds(expire_seconds), TimeSpan.Zero);
            }
            catch(Exception e)
            {

            }
        }
    }
}