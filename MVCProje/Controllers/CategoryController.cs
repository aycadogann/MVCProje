using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje.Models.Entity;

namespace MVCProje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        ShopBaseDbEntities db = new ShopBaseDbEntities();
        public ActionResult Index()
        {
            var values = db.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Categories categories)
        {
            db.Categories.Add(categories);
            db.SaveChanges();
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categroy = db.Categories.Find(id);
            db.Categories.Remove(categroy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCategory(int id)
        {
            var category = db.Categories.Find(id);
            return View("GetCategory", category);
        }
        public ActionResult UpdateCategory(Categories category)
        {
            var _category = db.Categories.Find(category.CategoryId);
            _category.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}