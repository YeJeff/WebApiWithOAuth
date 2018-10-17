using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using WxPublic.Utility;

namespace WxPublic.Config
{
    public class WxConfigure
    {
        /// <summary>
        /// 用于在全局cache中存储普通access_token的键名
        /// </summary>
        public const string AcessTokenCacheKey = "g_access_token";

        /// <summary>
        /// 用于在全局cache中存储jsapi_token的键名
        /// </summary>
        public const string JsaqpiTokenCacheKey = "jsaqpi_token";
        /// <summary>
        /// 公众号唯一标识
        /// </summary>
        public static string WxAppid => ConfigurationManager.AppSettings["wx:appid"].Trim();
        
        /// <summary>
        /// 公众号内设置的app密钥
        /// </summary>
        public static string WxAppsecret => ConfigurationManager.AppSettings["wx:appsecret"].Trim();

        /// <summary>
        /// 网页授权code换取access_token(网页授权)的URL模版，使用string.Format(AccessTokenGetUrlTemplate, wxAppid, wxAppsecret, code)格式化
        /// </summary>
        public static string AccessTokenGetUrlTemplate => "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";

        /// <summary>
        /// 获取普通access_token(注意与网页授权access_token的区别)
        /// </summary>
        public static string GeneralAccessTokenGetUrl => $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={WxAppid}&secret={WxAppsecret}";

        /// <summary>
        /// 通过普通accsss_token换取jsapi
        /// </summary>
        public static string JsapiTokenGetUrlTemplate => "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";
    }
}