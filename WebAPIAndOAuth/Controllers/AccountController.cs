using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using System.Data.Entity;
using WebAPIAndOAuth.Models;
using WebAPIAndOAuth.Infrastructure;
using System;
using System.Data.Entity.Core.Objects;

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


        public async Task<IHttpActionResult> Get()
        {
            using (var db = new AuthDbContext())
            {
                db.Database.Log = (sql) =>
                {

                    System.Diagnostics.Debug.WriteLine(sql);
                };

                #region Query
                //db.Configuration.LazyLoadingEnabled = false;
                //var isLazy = db.Configuration.LazyLoadingEnabled;

                //BankAccount bc = db.BankAccounts.FirstOrDefault();
                ////BillingDetail bl = bc.BillingDetail;
                //return Ok(new { Succeed = 1, BC = bc });
                #endregion


                BillingDetail bl = new BillingDetail
                {
                    BillingDetailId = 1,
                    Note263 = DateTime.Now.ToLocalTime().ToString(),
                    Number = "number",
                    Owner = "dog"
                };



                var originalSetting = db.Configuration.AutoDetectChangesEnabled;
                db.Configuration.AutoDetectChangesEnabled = false;

                bl = db.BillingDetails.Where(w => w.BillingDetailId == 12).FirstOrDefault();

                return Ok(bl);

            }

        }
    }
}
