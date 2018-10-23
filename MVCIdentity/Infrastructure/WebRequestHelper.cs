using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;

namespace MVCIdentity.Infrastructure
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

        public async static Task<string> HttpClientPostAsync(string url, Dictionary<string, string> postData)
        {
            return await HttpClientPostAsync(url, null, null, postData);
        }

        public async static Task<string> HttpClientPostAsync(string url, Dictionary<string, string> requestHeaders, Dictionary<string, string> requestCookies, Dictionary<string, string> postData)
        {
            HttpClient client = null;
            try
            {
                // Setting request cookies
                if (requestCookies != null)
                {
                    CookieContainer cookieContainer = new CookieContainer();
                    foreach (KeyValuePair<string, string> kp in requestCookies)
                    {
                        cookieContainer.Add(new Cookie(kp.Key, kp.Value));
                    }

                    HttpClientHandler httpClientHandler = new HttpClientHandler
                    {
                        CookieContainer = cookieContainer,
                        AllowAutoRedirect = true,
                        UseCookies = true
                    };
                    client = new HttpClient(httpClientHandler);
                }
                else
                {
                    client = new HttpClient();
                }

                // Setting request headers
                if (requestHeaders != null)
                {
                    foreach (KeyValuePair<string, string> kp in requestHeaders)
                    {
                        client.DefaultRequestHeaders.Add(kp.Key, kp.Value);
                    }
                }

                // Setting request data
                HttpContent requestBody = new FormUrlEncodedContent(postData);

                client.Timeout = TimeSpan.FromSeconds(30);
                HttpResponseMessage rspMsg = await client.PostAsync(url, requestBody);
                HttpResponseMessage rspStatus = rspMsg.EnsureSuccessStatusCode();

                if(rspStatus.StatusCode == HttpStatusCode.OK)
                {
                    return await rspStatus.Content.ReadAsStringAsync();
                }
                return null;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}