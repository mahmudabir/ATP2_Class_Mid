using Inventory_with_Repository_Pattern.Models;
using Inventory_with_Repository_Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_with_Repository_Pattern.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository proRepo = new ProductRepository();
        // GET: Product


        //State Management
        //Session Management
        //1. InProc
        //2. StateServer
        //3. SqlServer  
        //4. Custom
        //5. Off
        public ActionResult Index()
        {
            Session["test"] = "Hello from session";
            return View(proRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            //if (Session["test"] == null)
            //{
            //    return RedirectToAction("Index");
            //}
            CategoryRepository catRepo = new CategoryRepository();
            ViewData["categories"] = catRepo.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                proRepo.Insert(p);
                return RedirectToAction("Index");
            }

            CategoryRepository catRepo = new CategoryRepository();
            ViewData["categories"] = catRepo.GetAll();
            return View();

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CategoryRepository catRepo = new CategoryRepository();
            ViewData["categories"] = catRepo.GetAll();
            return View(proRepo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            proRepo.Update(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            return View(proRepo.Get(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            proRepo.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Top()
        {

            return View(proRepo.GetTopProducts(2));
        }

        [NonAction]
        public int calculate()
        {
            return 10 + 10;
        }


    }
}