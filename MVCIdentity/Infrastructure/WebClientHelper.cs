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

        public async static Task<String> HttpClientPost(string url, Dictionary<string, string> postData)
        {
            // Setting cookies
            CookieContainer cookies = new CookieContainer();
            cookies.Add(new Cookie("Authorization", "Bearer sdfsadfasdfsadfsadfsdf"));

            // Construct a HttpClientHandler using cookies
            HttpClientHandler httpClientHandler = new HttpClientHandler
            {
                CookieContainer = cookies,
                AllowAutoRedirect = true,
                UseCookies = true
            };

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(30);

                // Setting request header
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.62 Safari/537.36");
                new string()
            }
        }

        public async static Task<string> HttpClientPostAsync(string url, Dictionary<string, string> requestHeaders, Dictionary<string, string> requestCookies, Dictionary<string, string> postData)
        {
            if (!(requestHeaders is null))
            return null;
        }
    }
}