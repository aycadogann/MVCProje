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
    }
}