using System.Web.Http;
using System.Net.Http;
using Microsoft.AspNet.Identity.Owin;
using WebAPIAndOAuth.Infrastructure;
using Microsoft.AspNet.Identity;

namespace WebAPIAndOAuth.Controllers
{
    public class BaseController : ApiController
    {
        protected AppUserManager UserMgr => Request.GetOwinContext().GetUserManager<AppUserManager>();

        protected void AddErrorsFromResult (IdentityResult result)
        {
            foreach(string err in result.Errors)
            {
                ModelState.AddModelError("", err);
            }
        }
    }
}
