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


        //Form Data Access
        //1. Request
        //2. FormControl
        //3. Parameters
        //4. Model Binding

        [HttpPost]
        //1
        //public ActionResult FormProcess(FormCollection fc)
        //{
        //    string username = Request["name"].ToString();
        //    return Content(username);
        //}

        //2
        //public ActionResult FormProcess(FormCollection fc)
        //{
        //    //string username = Request["name"].ToString();
        //    string username = fc["username"].ToString();
        //    return Content(username);
        //}

        //3
        //public ActionResult FormProcess(string username, string password)
        //{

        //    return Content(username+"->"+password);
        //}


        //4
        public ActionResult FormProcess(Person p, string hobby, Other o)
        {

            return Content(p.Name +"->"+p.Username + "->" + p.Password + "->" + hobby + "->" + o.FavouriteFood);
        }


    }
}