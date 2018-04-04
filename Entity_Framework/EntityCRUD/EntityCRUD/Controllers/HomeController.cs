using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityCRUD.Models;

namespace EntityCRUD.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            var data = db.Persons.SqlQuery("select * from tblDetails").ToList();
            return View(data);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var data = db.Persons.SqlQuery("select * from tblDetails where Id = @p0", id).SingleOrDefault();
            return View(data);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Person collection)
        {
            try
            {
                // TODO: Add insert logic here

                List<object> list = new List<object>();
                list.Add(collection.Name);
                list.Add(collection.Gender);
                list.Add(collection.Email);
                list.Add(collection.City);
                list.Add(collection.Country);
                list.Add(collection.Mobile);

                object[] allItems = list.ToArray();
                int output = db.Database.ExecuteSqlCommand("insert into tblDetails (Name, Gender, Email, City, Country, Mobile) values (@p0, @p1, @p2, @p3, @p4, @p5)", allItems);

                if (output > 0)
                {
                    ViewBag.message = "Details are added successfully!!!";
                }

                return View();

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.Persons.SqlQuery("select * from tblDetails where Id = @p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person collection)
        {
            try
            {
                // TODO: Add update logic here

                List<object> list = new List<object>();
                list.Add(collection.Name);
                list.Add(collection.Gender);
                list.Add(collection.Email);
                list.Add(collection.City);
                list.Add(collection.Country);
                list.Add(collection.Mobile);

                object[] objectItems = list.ToArray();
                int outputData = db.Database.ExecuteSqlCommand("Update tblDetails set Name='" + collection.Name + "',Gender='" + collection.Gender + "',Email='" + collection.Email + "',City='" + collection.City + "',Country='" + collection.Country + "',Mobile='" + collection.Mobile + "' where id='" + collection.Id + "'");

                if (outputData > 0)
                {
                    ViewBag.editMessage = "Details are Edited successfully!!!";
                }

                return View();

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.Persons.SqlQuery("select * from tblDetails where Id = @p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Person collection)
        {
            try
            {
                // TODO: Add delete logic here

                var personList = db.Database.ExecuteSqlCommand("delete from tblDetails where Id = @p0", id);
                if (personList != 0)
                {
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
