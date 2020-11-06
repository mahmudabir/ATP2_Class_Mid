using IMS_with_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_with_Entity_Framework.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        InventoryDB context = new InventoryDB();

        [HttpGet]
        public ActionResult Index()
        {
            //LINQ - Language Integrated Query
            //Lambda Expression


            //LINQ
            //var categoryList = from item in context.Categories
            //                   select item;
            //return View(categoryList.ToList());


            //Lambda Expression
            //var categoryList = context.Categories.ToList();
            //return View(categoryList);

            return View(context.Categories.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            //LINQ
            //var categoryToUpdate = from item in context.Categories
            //                       where item.CategoryId == id
            //                       select item;
            //return View(categoryToUpdate.FirstOrDefault());


            //Lambda Expression
            var categoryToUpdate = context.Categories.Where(x => x.CategoryId == id);
            return View(categoryToUpdate.FirstOrDefault());

            //return View(context.Categories.Where(x => x.CategoryId == id).FirstOrDefault());
            //return View(context.Categories.Find(id)); // id must be a primary key. or it may return multiple results
        }


        [HttpPost]
        public ActionResult Edit(Category category)
        {
            ////LINQ
            //var result = from item in context.Categories
            //             where item.CategoryId == category.CategoryId
            //             select item;

            //Category categoryToUpdate = result.FirstOrDefault();
            //categoryToUpdate.CategoryName = category.CategoryName;
            ////context.Categories.AddOrUpdate(categoryToUpdate);
            //context.SaveChanges();
            //return RedirectToAction("Index");


            var result = context.Categories.Where(x => x.CategoryId == category.CategoryId);
            Category categoryToUpdate = result.FirstOrDefault();
            categoryToUpdate.CategoryName = category.CategoryName;
            //context.Categories.AddOrUpdate(categoryToUpdate);
            context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}