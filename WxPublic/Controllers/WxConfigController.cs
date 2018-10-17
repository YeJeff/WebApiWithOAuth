using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Threading.Tasks;
using System.Net.Http.Headers;

using WxPublic.Utility;
using WxPublic.Config;
using WxPublic.Models.WxModels;

namespace WxPublic.Controllers
{
    [RoutePrefix("api/WxConfig")]
    public class WxConfigController : ApiController
    {
        /// <summary>
        /// 微信公众平台网页授权的方式获得acces_token及openid
        /// </summary>
        /// <param name="code">微信网页授权code</param>
        /// <returns></returns>
        [Route("code/{code}")]
        public async Task<IHttpActionResult> GetUserID(string code)
        {
            string userID = string.Empty;
            string accessTokenGetUrl = string.Format(WxConfigure.AccessTokenGetUrlTemplate,
                WxConfigure.WxAppid, WxConfigure.WxAppsecret, code);

            WebAccessToken token = await WxHelper.GetWebAccessTokenAsync(accessTokenGetUrl);
            userID = token.OpenId;

            return Ok(token);
        }

        [Route("url/{url}")]
        public async Task<IHttpActionResult> GetWxSignature(string url)
        {
            return Ok(await WxHelper.GetWxSignature(url));
            //return Ok(await WxHelper.GetGeneralAccessTokenAsync());
        }

        
    }
}
