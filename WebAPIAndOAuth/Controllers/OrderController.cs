using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace WebAPIAndOAuth.Controllers
{
    [Authorize(Roles = "admin")]
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        public IHttpActionResult Get()
        {
            var identity = Request.GetOwinContext().Authentication.User.Identity;
            return Ok(new { UserName = identity.Name, AuthType = identity.AuthenticationType,Pid = 10, name = "ok" });
        }
    }
}
