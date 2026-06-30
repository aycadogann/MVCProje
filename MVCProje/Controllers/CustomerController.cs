using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCProje.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        ShopBaseDbEntities db = new ShopBaseDbEntities();
        public ActionResult Index(int page=1)
        {
            //var values = db.Customers.OrderByDescending(x => x.CustomerId).ToList();
            var values = db.Customers.ToList().ToPagedList(page,10);
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
            if (!ModelState.IsValid)
            {
                return View("AddCustomer");
            }
            customer.CustomerIsActive = 1;
            customer.CustomerCreatedDate = DateTime.Now;
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            return View("GetCustomer", customer);
        }

        public ActionResult UpdateCustomer(Customers customer)
        {
            var _customer = db.Customers.Find(customer.CustomerId);
            _customer.CustomerName = customer.CustomerName;
            _customer.CustomerSurname = customer.CustomerSurname;
            _customer.CustomerEmail = customer.CustomerEmail;
            _customer.CustomerDistrict = customer.CustomerDistrict;
            _customer.CustomerCity = customer.CustomerCity;
            _customer.CustomerCountry = customer.CustomerCountry;
            _customer.CustomerGender = customer.CustomerGender;
            _customer.CustomerBalance = customer.CustomerBalance;
            _customer.CustomerCreatedDate = DateTime.Now;
            _customer.CustomerIsActive = 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}