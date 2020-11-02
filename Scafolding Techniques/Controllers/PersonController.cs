using Scafolding_Techniques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scafolding_Techniques.Controllers
{
    public class PersonController : Controller
    {

        static List<Person> persons = new List<Person>() {
            new Person() { Id=1 , Name="hasib" ,Email="hasib@gmail.com" , Salary=20000} ,
            new Person() { Id=2 , Name="abir" ,Email="abir@gmail.com" , Salary=20000} ,
            new Person() { Id=3 , Name="rafi" ,Email="rafi@gmail.com" , Salary=20000} ,
            new Person() { Id=4 , Name="leon" ,Email="leon@gmail.com" , Salary=20000} ,

        };
        // GET: Person
        public ActionResult Index()
        {
            return View(persons);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var person = from item in persons where item.Id == id select item;

            Person p = persons.Where(x => x.Id==id).First();

            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(int id, Person p)
        {
            // DB update operation
            Person personToUpdate = persons.Where(x => x.Id == id).First();
            personToUpdate.Id = id;
            personToUpdate.Name = p.Name;
            personToUpdate.Email = p.Email;
            personToUpdate.Salary = p.Salary;
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person p)
        {
            persons.Add(p);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Person p = persons.Where(x => x.Id == id).First();
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(int id, Person p)
        {
            var item = persons.Where(x => x.Id == id).First();
            persons.Remove(item);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            Person p = persons.Where(x => x.Id == id).First();
            return View(p);
        }

        //[HttpPost]
        //public ActionResult Details(int id, Person p)
        //{
        //    var item = persons.Where(x => x.Id == id).First();
        //    persons.Remove(item);
        //    return RedirectToAction("Index");
        //}


    }
}