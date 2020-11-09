using Inventory_with_Repository_Pattern.Models;
using Inventory_with_Repository_Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_with_Repository_Pattern.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository catRepo = new CategoryRepository();
        // GET: Category
        public ActionResult Index()
        {
            return View(catRepo.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cat)
        {
            catRepo.Insert(cat);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            return View(catRepo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            catRepo.Update(cat);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {

            return View(catRepo.Get(id));
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            catRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}