using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ang.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            noteLogic.department o = new noteLogic.department();
            var list=o.displayDepartments();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

       
    }
}