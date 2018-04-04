using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCRUDCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityCRUDCore.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Persons.ToList();
            return View(data);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var data = db.Persons.Find(id);
            return View(data);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person collection)
        {
            try
            {
                // TODO: Add insert logic here
                db.Add(collection);
                int output = db.SaveChanges();

                if (output > 0)
                {
                    ViewBag.message = "Details are added successfully!!!";
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.Persons.Find(id);
            return View(data);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Person collection)
        {
            try
            {
                // TODO: Add update logic here
                db.Persons.Update(collection);
                int outputData = db.SaveChanges();

                if (outputData != 0)
                {
                    ViewBag.editMessage = "Details are updated successfully!!!";
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.Persons.Find(id);
            return View(data);
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var data = db.Persons.Find(id);
                db.Persons.Remove(data);
                int output = db.SaveChanges();
                if (output > 0)
                {
                    ViewBag.deleteMessage = "Details are deleted successfully!!!";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}