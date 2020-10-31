using Data_Passing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Passing.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        [HttpGet]
        public ActionResult Index()
        {
             return View();
        }


        [HttpPost]
        public ActionResult Index(Person p, string confirm_password)
        {

            TempData["person"] = p;
            return RedirectToAction("Another");
        }


        [HttpGet]
        public ActionResult Another()
        {
            Person p = TempData["Person"] as Person;
            return View(p);
        }


    }
}