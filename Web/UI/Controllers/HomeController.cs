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
using UI.Security;
using UI.Session;
using Web.Process;

namespace UI.Controllers
{
    [SessionCookie]
    [IsLogged]
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

        public IActionResult LogIn(string redirectTo)
        {
            var controller = string.IsNullOrWhiteSpace(redirectTo) ? "Home" : redirectTo;
            TempData["redirectTo"] = controller;
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(User user)
        {
            try
            {
                var _user = new UserProcess().LogIn(user);
                if(_user == null)
                    return View(user);
                Console.WriteLine(_user.Roles.Count);
                Cache.Add(
                    Request.Cookies.FirstOrDefault(x => x.Key == ".leathergoods").Value,
                    _user
                );
                var controller = TempData["redirectTo"] != null ? TempData["redirectTo"].ToString() : "Home";
                TempData.Remove("redirectTo");
                return RedirectToAction("Index", controller);
            }
            catch(Exception ex)
            {
                ViewData["error"] = ex.Message;
                return View(user);
            }
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
