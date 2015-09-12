using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Security;

namespace MvcApplication1.Models
{

    public class Account
    {
        //[Required]
        //[Display(Name = "User name")]
        //public string UserName { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        public string Uid { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        //public string Password { get; set; }
        //public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        public int Mobile { get; set; }
        public bool IsTrue { get; set; }
        public IEnumerable<HttpPostedFileBase> DiseaseReports { get; set; }
        public string Message { get; set; }
    }

    public class RootObject
    {
        public List<List<string>> HealthData { get; set; }
        public string SelectedState { get; set; }
    }
}

