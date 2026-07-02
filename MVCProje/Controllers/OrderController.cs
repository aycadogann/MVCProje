using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje.Models.Entity;

namespace MVCProje.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        ShopBaseDbEntities db = new ShopBaseDbEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrder(Orders order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return View("Index");
        }
    }
}