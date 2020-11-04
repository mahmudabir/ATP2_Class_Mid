using Inventory_Management_System_with_ADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Inventory_Management_System_with_ADO.NET.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        [HttpGet]
        public ActionResult Index()
        {
            ProductDataAccess pda = new ProductDataAccess();
            return View(pda.GetAllProducts());
        }

        [HttpGet]
        public ActionResult Create()
        {
            CategoryDataAccess cda = new CategoryDataAccess();
            ViewData["cats"]= cda.GetAllCategories();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            ProductDataAccess pda = new ProductDataAccess();
            int i = pda.InsertProduct(product);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductDataAccess pda = new ProductDataAccess();
            return View(pda.GetProductById(id));
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            ProductDataAccess pda = new ProductDataAccess();
            int i = pda.UpdateProduct(product);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ProductDataAccess pda = new ProductDataAccess();
            return View(pda.GetProductById(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            ProductDataAccess pda = new ProductDataAccess();
            int i = pda.DeleteProduct(id);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}