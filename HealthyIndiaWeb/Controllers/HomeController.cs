using HealthyIndia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthyIndiaWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                var healthyIndiaRepo = new HealthyIndiaRepository();
                try
                {
                    if (user.UID != null)
                    {
                        var result = healthyIndiaRepo.Save(user);
                    }

                }
                catch (Exception ex)
                {

                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ValidateUID(string uid)
        {
            if (uid != null)
            {
                var healthyIndiaRepo = new HealthyIndiaRepository();
                var result = healthyIndiaRepo.Get(uid);
                if (result != null)
                {
                    return Json(new { status = 200, msg = "UID Exists.", name = result.Name, age = result.Age, sex = result.Sex, uid = result.UID, images = result.LastDiseasesReported }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { status = 0, msg = "No UID found." }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { status = 0, msg = "No UID found." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
