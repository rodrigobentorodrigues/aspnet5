﻿using System.Web.Mvc;

namespace Course.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        
        [OutputCache(Duration = 50)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}