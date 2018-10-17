using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using WebAPIAndOAuth.Infrastructure;

namespace WebAPIAndOAuth.Controllers
{
    [Authorize(Roles = "admin")]
    [RoutePrefix("api/RefreshToken")]
    public class RefreshTokenController : BaseController
    {

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(Request.GetOwinContext().Get<AuthDbContext>().RefreshTokens);
        }

        [Route("")]
        public async Task<IHttpActionResult> Delete(string tokenId)
        {
            using (AuthRepository authRepo = new AuthRepository())
            {
                var result = await authRepo.RemoveRefreshTokenAsync(tokenId);
                if (result)
                {
                    return Ok();
                }                
            }
            return BadRequest($"Refresh token (id: {tokenId}) does not exists.");
        }
    }
}
