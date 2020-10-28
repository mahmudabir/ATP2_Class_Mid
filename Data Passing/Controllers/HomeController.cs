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

        //Session
        //ViewData
        //ViewBag
        //TempData
        //Model: ViewModel, DataModel

        //public ActionResult Index()
        //{
        //    if (Request.HttpMethod=="GET")
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return Content("<h2>It works</h2>");
        //    }

        //    //return View();
        //}


        public ActionResult Index()
        {
            if (Request.HttpMethod == "GET")
            {
                return View();
            }
            else
            {
                TempData["name"] = Request["name"];
                TempData["username"] = Request["username"];
                TempData["blood_group"] = Request["blood_group"];
                TempData["gender"] = Request["gender"];
                TempData["dob"] = Request["dob"];
            }

            return RedirectToAction("Another");
        }


        public ActionResult Another()
        {
            Person p = new Person { name = "Raiyan Rafi", emails = "rafi@gmail.com" };

            // accessible throughout the whole session
            //Session["mname"] = "Abir Mahmud";

            // accessible for 1st successful view response but after returning once tempdata is unavailable
            //TempData["oname"] = "Abdul Alim";//Can assign through another model to here when redirected to this controller

            //Just like viewbad but uses associative array concept & also accessible for one response
            //ViewData["fname"] = "Abir";

            //accessible from the view from which the viewbag was assigned & follows the object oriented concept & also accessible for one response
            //ViewBag.lname = "Mahmud";

            //ViewModel used Passing Value controller to view


            //DataModel used for data related operations

            return View();
        }
    }
}