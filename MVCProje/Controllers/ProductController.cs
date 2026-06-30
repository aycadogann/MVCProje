using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje.Models.Entity;

namespace MVCProje.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ShopBaseDbEntities db = new ShopBaseDbEntities();
        public ActionResult Index()
        {
            var values = db.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> values = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryId.ToString()
                                           }).ToList();
            ViewBag.categories = values;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Products product)
        {
            var category = db.Categories.Where(c => c.CategoryId == product.Categories.CategoryId).FirstOrDefault();
            product.Categories = category;
            product.ProductCreatedDate = DateTime.Now;
            product.ProductIsActive = true;
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int id)
        {
            var product = db.Products.Find(id);
            List<SelectListItem> values = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryId.ToString()
                                           }).ToList();
            ViewBag.categories = values;
            return View("GetProduct", product);
        }

        public ActionResult UpdateProduct(Products product)
        {
            var _product=db.Products.Find(product.ProductId);
            _product.ProductName = product.ProductName;

            var category = db.Categories.Where(c => c.CategoryId == product.Categories.CategoryId).FirstOrDefault();
            _product.Categories = category;

            _product.ProductPrice = product.ProductPrice;
            _product.ProductStock = product.ProductStock;
            _product.ProductDescription = product.ProductDescription;
            _product.ProductCreatedDate = DateTime.Now;
            _product.ProductIsActive = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}