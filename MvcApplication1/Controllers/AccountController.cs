using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
//using MvcApplication1.Filters;
using MvcApplication1.Models;
using CsvHelper;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using System.Web;

namespace MvcApplication1.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //[AllowAnonymous]
        //[HttpGet]
        //public ActionResult Login(Account model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (!string.IsNullOrEmpty(Convert.ToString(TempData["ErrorMessage"])))
        //        {
        //            ViewBag.Message = TempData["ErrorMessage"];
        //        }
        //    }
        //    return View("~\\Views\\Account\\HealthHistory.cshtml", new Account());
        //}
        //[HttpPost]
        //[AllowAnonymous]
        ////[ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        //public ActionResult Authenticate(Account login)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }

        //    return PartialView("~\\Views\\Account\\Login.cshtml", new Login());
        //}


        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateInput(false)]
        [AllowAnonymous]
        public ActionResult Authenticate(Account model, IEnumerable<HttpPostedFileBase> file)
        {
            var path = @"D:\UserData\" + string.Format("userDetails-{0}.json", model.Uid) + "";
            var json1 = JsonConvert.DeserializeObject<Account>(System.IO.File.ReadAllText(path));
            model.IsTrue = false;
            if (json1.Age > 0)
            {
                model.IsTrue = true;
                model.Age = json1.Age;
                model.Gender = json1.Gender;
                model.Mobile = json1.Mobile;
            }
            return PartialView("~\\Views\\home\\HealthHistory.cshtml", model);
        }        

        // POST: /Account/JsonRegister
        //[HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Account model)
        {            
                var file = @"D:\UserData\" + string.Format("userDetails-{0}.json", model.Uid);
                string json = JsonConvert.SerializeObject(model);
                //write string to file
                System.IO.File.WriteAllText(file, json);
                //var json1 = JsonConvert.DeserializeObject<Account>(System.IO.File.ReadAllText(file));
                
                model.Message = "Sucessfully registered.Please login";
                return PartialView("~\\Views\\home\\HealthHistory.cshtml", model);
        }

    }
}