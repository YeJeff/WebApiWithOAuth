using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MVCIdentity.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace MVCIdentity.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            throw new Exception("custome error...");
            //return View();

        }

        public async Task<ActionResult> WebApiCall([Required]string url)
        {
            string result = string.Empty;
            if (ModelState.IsValid)
            {
                result = await WebRequestHelper.HttpClientGet(url);
            }

            RspModel rspModel = JsonConvert.DeserializeObject<RspModel>(result);

            ViewBag.WebApiResult = result;
            return View();
        }
    }

    public class RspModel
    {
        public string BillingDetailId { get; set; }
        public string Owner { get; set; }
        public string Note263 { get; set; }
        public int CID { get; set; }
    }
}