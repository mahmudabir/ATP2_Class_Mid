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
        public ActionResult Index()
        {
            return View(proRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            CategoryRepository catRepo = new CategoryRepository();
            ViewData["categories"] = catRepo.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            proRepo.Insert(p);
            return RedirectToAction("Index");
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
        [HttpPost,ActionName("Delete")]
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

       
    }
}