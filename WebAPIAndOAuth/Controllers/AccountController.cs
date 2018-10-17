using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using WebAPIAndOAuth.Models;
using WebAPIAndOAuth.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;

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
            var db = Request.GetOwinContext().Get<AuthDbContext>();
            db.Database.Log = (sql) =>
            {

                System.Diagnostics.Debug.WriteLine(sql);
            };

            BankAccount bankAccount = new BankAccount
            {
                BankName = "BOC",
                Number = "9876541230",
                Owner = "jack",
                Swift = "OK"
            };

            CreditCard creditCard = new CreditCard
            {
                CardType = 995,
                ExpiryMonth = "12",
                Number = "123123123123",
                ExpiryYear = "1",
                Owner = "jack",
                Note263 = "Yes"
            };
            db.BillingDetails.Add(bankAccount);
            db.BillingDetails.Add(creditCard);

            var result = await db.SaveChangesAsync();
            return Ok(new { Succeed = result, BC = bankAccount, CC = creditCard});

           // var result = await db.BillingDetails.AsNoTracking().Where(b => b.BillingDetailId == 1 || b.BillingDetailId == 2).ToListAsync();

            
           // return Json(result);
        }
    }
}
