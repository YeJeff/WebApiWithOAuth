using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Text;

using WxPublic.Config;
using WxPublic.Models.WxModels;

namespace WxPublic.Utility
{
    public class WxHelper
    {
        /// <summary>
        /// 使用HttpClient及Http Get方法访问指定url
        /// </summary>
        /// <typeparam name="T">待返回的对象</typeparam>
        /// <param name="url">将要访问的url地址</param>
        /// <returns>微信token</returns>
        /// 
        private async static Task<T> GetTokenFromHttpRspAsync<T>(string url) where T : BaseWxToken
        {
            T token = default(T);
            string rspString = await WebRequestHelper.HttpClientGet(url);

            if (!string.IsNullOrEmpty(rspString))
            {
                token = JsonHelper.ToObject<T>(rspString);
                token.RspMsg = rspString;
                token.RequestUrl = url;
            }

            return token;
        }

        /// <summary>
        /// 获取网页授权access_token
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async static Task<WebAccessToken> GetWebAccessTokenAsync(string url)
        {
            WebAccessToken token = await GetTokenFromHttpRspAsync<WebAccessToken>(url);

            return token;
        }

        /// <summary>
        /// 获取微信公众平台普通access_token
        /// </summary>
        /// <returns>微信公众平台普通access_token（可用于获取微信公众平台jsapi_token）</returns>
        public async static Task<string> GetGeneralAccessTokenAsync()
        {
            string accessToken = CacheHelper.GetCache<string>(WxConfigure.AcessTokenCacheKey);

            if (accessToken is null)
            {
                GeneralAccessToken tokenObj = await GetTokenFromHttpRspAsync<GeneralAccessToken>(WxConfigure.GeneralAccessTokenGetUrl);
                accessToken = tokenObj.Access_token;

                if (!string.IsNullOrEmpty(accessToken))
                {
                    CacheHelper.UpdateOrSetCache(WxConfigure.AcessTokenCacheKey, accessToken, tokenObj.Expires_in);
                }
                else
                {
                    throw new Exception(JsonHelper.SerializeObject(tokenObj));
                }
            }

            return accessToken;
        }

        /// <summary>
        /// 获取用于计算签名的jsapi_token
        /// </summary>
        /// <returns>用于计算签名的jsapi_token</returns>
        public async static Task<string> GetJsapiTokenAsync()
        {
            string jsapiToken = CacheHelper.GetCache<string>(WxConfigure.JsaqpiTokenCacheKey);

            if (jsapiToken is null)
            {
                string accessToken = await GetGeneralAccessTokenAsync();
                JsapiToken tokenObj = await GetTokenFromHttpRspAsync<JsapiToken>(string.Format(WxConfigure.JsapiTokenGetUrlTemplate, accessToken));
                jsapiToken = tokenObj.Ticket;

                if (!string.IsNullOrEmpty(jsapiToken))
                {
                    CacheHelper.UpdateOrSetCache(WxConfigure.JsaqpiTokenCacheKey, jsapiToken, tokenObj.Expires_in);
                }
                else
                {
                    throw new Exception(JsonHelper.SerializeObject(tokenObj));
                }
            }

            return jsapiToken;
        }

        public async static Task<WxSignature> GetWxSignature(string url)
        {
            string jsapiToken = await GetJsapiTokenAsync();
            string noncestr = Guid.NewGuid().ToString();
            long timestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
            url = HttpUtility.UrlDecode(url);

            string originalString = $"jsapi_ticket={jsapiToken}&noncestr={noncestr}&timestamp={timestamp}&url={url}";
            string signature = originalString.Sha1Encrypt(Encoding.UTF8);

            return new WxSignature {Success = 1,
                Noncestr = noncestr,
                Timestamp = timestamp,
                Url =url,
                Signature = signature };
        }
    }
}