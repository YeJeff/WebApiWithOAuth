using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Net.Http;
using System.Data.Entity;
using WebAPIAndOAuth.Models;
using WebAPIAndOAuth.Infrastructure;
using System;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

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

        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            using (var db = new AuthDbContext())
            {
                //db.Database.Log = (sql) =>
                //{

                //    System.Diagnostics.Debug.WriteLine(sql);
                //};


                //foreach(var ba in db.BillingDetails.Local)
                //{
                //    System.Diagnostics.Debug.WriteLine($"{ba.BillingDetailId}, {ba.Number}, {ba.Owner}, {ba.Note263}");
                //}

                //var row =db.BillingDetails.Find(2);
                //row.Owner = "jeff";
                ////db.BillingDetails.Load();

                //foreach (var ba in db.BillingDetails.Local)
                //{
                //    System.Diagnostics.Debug.WriteLine($"{ba.BillingDetailId}, {ba.Number}, {ba.Owner}, {ba.Note263}, {db.Entry(ba).State}");
                //}

                //foreach(var ba in db.BillingDetails)
                //{
                //    System.Diagnostics.Debug.WriteLine($"{ba.BillingDetailId}, {ba.Number}, {ba.Owner}, {ba.Note263}, {db.Entry(ba).State}");
                //}

                //db.SaveChanges();

                //foreach (var ba in db.BillingDetails.Local)
                //{
                //    System.Diagnostics.Debug.WriteLine($"{ba.BillingDetailId}, {ba.Number}, {ba.Owner}, {ba.Note263}, {db.Entry(ba).State}");
                //}

                //foreach (var ba in db.BillingDetails)
                //{
                //    System.Diagnostics.Debug.WriteLine($"{ba.BillingDetailId}, {ba.Number}, {ba.Owner}, {ba.Note263}, {db.Entry(ba).State}");
                //}
                
                var ba = db.BankAccounts.First();

                return Ok();
                //return Json(ba);
            }
        }

    }


}