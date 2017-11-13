using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Framework.Cache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Models;
using UI.Session;
using Web.Process;

namespace UI.Controllers
{
    [SessionCookie]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(User user)
        {
            var _user = new UserProcess().LogIn(user);
            if(_user == null)
                return View(user);
            Cache.Add(
                Request.Cookies.FirstOrDefault(x => x.Key == ".leathergoods").Value,
                _user
            );
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            Cache.Remove(Request.Cookies.FirstOrDefault(x => x.Key == ".leathergoods").Value);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
