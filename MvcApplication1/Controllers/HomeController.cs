using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Default()
        {            
            return View();
        }

        [HttpGet]
        public ActionResult FirstAid()
        {
            return PartialView(@"~\Views\Home\FirstAid.cshtml");
        }

        [HttpGet]
        public ActionResult HealthHistory(Account model)
        {
            return PartialView(@"~\Views\Home\HealthHistory.cshtml",new Account());
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            return PartialView(@"~\Views\Home\Dashboard.cshtml");
        }

        [HttpPost]
        public ActionResult GetHospitalData(string inputData, string totalStates)
        {
            Dictionary<string, List<string>> stateHospList = null;
            List<string> uniqueStateList = new List<string>();
            try
            {
                if (inputData != null)
                {
                    var rootData = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(inputData);
                    var Data = rootData.HealthData;

                    uniqueStateList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(totalStates);
                    stateHospList = GetHospitalList(Data, uniqueStateList);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(new { HospitalDataDic = stateHospList }, JsonRequestBehavior.AllowGet);
        }

        private Dictionary<string, List<string>> GetHospitalList(List<List<string>> apiData, List<string> uniqueStateList)
        {
            Dictionary<string, List<string>> stateHospitalDic = new Dictionary<string, List<string>>();
            if (apiData != null)
            {
                foreach (var state in uniqueStateList)
                {
                    var tryDid = apiData.Where(t => t[0] == state).Select(t => t[1]).Distinct<string>().ToList();
                    if (!stateHospitalDic.ContainsKey(state))
                        stateHospitalDic.Add(state, tryDid);
                }
            }

            return stateHospitalDic;
        }
    }
}