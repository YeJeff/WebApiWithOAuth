using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxPublic.Models.WxModels
{
    public class WebAccessToken : BaseWxToken
    {
        /// <summary>
        /// 网页授权access_token
        /// </summary>
        public string Access_token { get; set; }

        /// <summary>
        // 网页授权access_token过期时间(s)
        /// </summary>
        public long Expires_in { get; set; }

        /// <summary>
        /// 刷新网页授权access_token的token
        /// </summary>
        public string Refresh_token { get; set; }

        /// <summary>
        /// openid - 每一个微信用户与每一个公众号都有唯一的一个标识
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 以逗号分隔的授权域 - snsapi_base / snsapi_userinfo
        /// </summary>
        public string Scope { get; set; }
    }
}