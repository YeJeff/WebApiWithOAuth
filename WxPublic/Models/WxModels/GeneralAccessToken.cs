using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxPublic.Models.WxModels
{
    public class GeneralAccessToken : BaseWxToken
    {
        /// <summary>
        /// access_token
        /// </summary>
        public string Access_token { get; set; }

        /// <summary>
        /// access_token过期时间，默认为7200(s)
        /// </summary>
        public long Expires_in { get; set; }
    }
}