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
    public class CategoryController : Controller
    {
        // GET: Category
        ShopBaseDbEntities db = new ShopBaseDbEntities();
        public ActionResult Index(int page=1)
        {
            //var values = db.Categories.ToList();
            var values = db.Categories.ToList().ToPagedList(page, 10);
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
            if (!ModelState.IsValid)
            {
                return View("AddCategory");
            }
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