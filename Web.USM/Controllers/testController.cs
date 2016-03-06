using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.USM.Controllers
{
    public class testController : Controller
    {
        // GET: test
        public ActionResult Index()
        {
            ViewBag.Message = "dddd";
            return View();
        }
    }
}