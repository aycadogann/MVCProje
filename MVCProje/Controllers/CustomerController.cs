using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje.Models.Entity;

namespace MVCProje.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        ShopBaseDbEntities db = new ShopBaseDbEntities();
        public ActionResult Index()
        {
            var values = db.Customers.OrderByDescending(x=>x.CustomerId).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customers customer)
        {
            customer.CustomerIsActive = 1;
            customer.CustomerCreatedDate = DateTime.Now;
            db.Customers.Add(customer);
            db.SaveChanges();
            return View();
        }
    }
}