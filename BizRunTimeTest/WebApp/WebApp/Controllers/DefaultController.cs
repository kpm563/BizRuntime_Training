using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DefaultController : Controller
    {
        ValidateData obj = new ValidateData();


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind] Registration user)
        {
            if (ModelState.IsValid)
            {
                obj.AddUser(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Login([Bind] Login login)
        {
            if (ModelState.IsValid)
            {

                if (obj.LoginUser(login))
                    return RedirectToAction("Home");
                else
                    login.Message = "Invalid UserName and Password";
            }
            return View(login);
        }


    }
}