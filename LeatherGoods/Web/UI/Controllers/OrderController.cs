using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Process;
using Entities;

namespace UI.Controllers
{
    public class OrderController : Controller
    {
        // GET: Orders/Order
        public ActionResult Index()
        {
            var op = new OrderProcess();
            var lista = op.SelectList();
            return View(lista);
        }

        // GET: Orders/Details
        public ActionResult Details(int id)
        {
            var op = new OrderProcess();
            var order = op.Find(id);

            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // POST: Orders/Create
        public ActionResult Create(Order order)
        {
            var op = new OrderProcess();
            op.Insert(order);
            return RedirectToAction("Index");
        }

        // GET: Orders/Delete
        public ActionResult Delete(int id)
        {
            var op = new OrderProcess();
            op.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Orders/Edit
        public ActionResult Edit(int id)
        {
            var op = new OrderProcess();
            var order = op.Find(id);

            return View(order);
        }

        [HttpPost]
        // POST: Orders/Edit
        public ActionResult Edit(Order order)
        {
            var op = new OrderProcess();
            op.Edit(order);
            return RedirectToAction("Index");
        }

    }
}
