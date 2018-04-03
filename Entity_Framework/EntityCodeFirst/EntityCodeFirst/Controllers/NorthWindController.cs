using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityCodeFirst.Models;

namespace EntityCodeFirst.Controllers
{
    public class NorthWindController : Controller
    {
        private NorthWindContext db = new NorthWindContext();

        // GET: NorthWind
        public ActionResult Index()
        {
            db.CategoriesTable.ToList();
            db.ProductsTable.ToList();
            return View();
        }
    }
}