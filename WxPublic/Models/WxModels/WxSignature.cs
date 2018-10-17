using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxPublic.Models.WxModels
{
    public class WxSignature:BaseWxModel
    {
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string Noncestr { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// 计算微信签名的Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 微信签名
        /// </summary>
        public string Signature { get; set; }
    }
}