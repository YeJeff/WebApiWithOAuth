using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using WxPublic.Models.WxModels;

namespace WxPublic.Utility
{
    public class WebRequestHelper
    {
        /// <summary>
        /// 使用HttpClient Get指定url返回的字符串
        /// </summary>
        /// <param name="url">将要访问的url地址</param>
        /// <returns>访问url返回的字符串</returns>
        public async static Task<String> HttpClientGet(string url)
        {
            string rspString = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, 10);
                HttpResponseMessage rspMsg = await client.GetAsync(new Uri(url));
                HttpResponseMessage rspStatus = rspMsg.EnsureSuccessStatusCode();
                if (rspStatus.StatusCode == HttpStatusCode.OK)
                {
                    rspString = await rspMsg.Content.ReadAsStringAsync();
                }
            }

            return rspString;
        }

        public async static Task<String> HttpClientPost(string url, Dictionary<string, string> postData)
        {
            throw new NotImplementedException();
        }
    }
}