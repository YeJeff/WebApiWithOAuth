using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxPublic.Models.WxModels
{
    public class BaseWxToken
    {
        /// <summary>
        /// 存储微信认证返回的原始字符串(json)
        /// </summary>
        public string RspMsg { get; set; }

        /// <summary>
        /// 请求URL
        /// </summary>
        public string RequestUrl { get; set; }
    }
}