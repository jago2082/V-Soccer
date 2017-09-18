using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V_Soccer.Models;

namespace V_Soccer.Controllers
{
    public class GenericController : Controller
    {
        private DataContext db = new DataContext();

        public JsonResult GetCities(int departmentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var cities = db.Cities.Where(c => c.DepartmentId == departmentId);
            return Json(cities);
        }

        public JsonResult GetStates(int countryId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var deparments = db.Departments.Where(d => d.CountryId == countryId);
            return Json(deparments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
