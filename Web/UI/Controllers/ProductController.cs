using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Process;
using Entities;
using UI.Session;

namespace UI.Controllers
{
    [SessionCookie]
    public class ProductController : Controller
    {
        // GET: Products/Product
        public ActionResult Index()
        {
            var pp = new ProductProcess();
            var lista = pp.SelectList();
            return View(lista);
        }

        // GET: Products/Details
        public ActionResult Details(int id)
        {
            var pp = new ProductProcess();
            var prd = pp.Find(id);

            return View(prd);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var dp = new DealerProcess();
            var lista = dp.SelectList();
            ViewData["Dealer"] = lista;
            return View();
        }

        [HttpPost]
        // POST: Products/Create
        public ActionResult Create(Product prd)
        {
            var pp = new ProductProcess();
            pp.Insert(prd);
            return RedirectToAction("Index");
        }

        // GET: Products/Delete
        public ActionResult Delete(int id)
        {
            var pp = new ProductProcess();
            pp.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Products/Edit
        public ActionResult Edit(int id)
        {
            var pp = new ProductProcess();
            var prd = pp.Find(id);

            return View(prd);
        }

        [HttpPost]
        // POST: Products/Edit
        public ActionResult Edit(Product prd)
        {
            var pp = new ProductProcess();
            pp.Edit(prd);
            return RedirectToAction("Index");
        }

    }
}
