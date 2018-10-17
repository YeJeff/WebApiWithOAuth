using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxPublic.Models.WxModels
{
    public class JsapiToken : BaseWxToken
    {
        /// <summary>
        /// 获取jsapi_token失败的code
        /// </summary>
        public Byte Errcode { get; set; }

        /// <summary>
        /// 获取jsapi_token失败的错误消息
        /// </summary>
        public string Errmsg { get; set; }

        /// <summary>
        /// jsapi_token
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// jsapi_token失效时间，默认7200（s）
        /// </summary>
        public long Expires_in { get; set; }
    }
}