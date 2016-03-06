using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.USM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Default()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult DashboardHome()
        {
            return View();
        }

        public ActionResult Help()
        {
            System.Threading.Thread.Sleep(2000);
            return View();
        }
    }
}