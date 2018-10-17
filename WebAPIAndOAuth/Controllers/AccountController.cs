using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using WebAPIAndOAuth.Models;
using WebAPIAndOAuth.Infrastructure;

namespace WebAPIAndOAuth.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : BaseController
    {
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AppUser user = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            IdentityResult result = await UserMgr.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                AddErrorsFromResult(result);
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}
