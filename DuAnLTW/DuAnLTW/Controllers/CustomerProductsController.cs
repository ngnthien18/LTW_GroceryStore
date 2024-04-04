using DuAnLTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace DemoWeb.Controllers
{
    public class CustomerProductsController : Controller
    {
        private DBGroceryEntities2 db = new DBGroceryEntities2();

        // GET: Products
        public ActionResult Products(string SearchString)
        {
            var products = db.Products.Include(p => p.Category);
            //Tìm kiếm chuỗi truy vấn theo NamePro, nếu chuỗi truy vấn SearchString khác rỗng, null
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.NamePro.Contains(SearchString));
            }
            return View(products.ToList());
        }
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products;
            return View(products.ToList());
        }
        public ActionResult Food()
        {
            var foods = db.Products.Where(p => p.Category.Contains("TP"));
            return View(foods.ToList());
        }
        public ActionResult Drink()
        {
            var drinks = db.Products.Where(p => p.Category.Contains("TU"));
            return View(drinks.ToList());
        }
        public ActionResult HMP()
        {
            var hmps = db.Products.Where(p => p.Category.Contains("HM"));
            return View(hmps.ToList());
        }
        public ActionResult Baby()
        {
            var babies = db.Products.Where(p => p.Category.Contains("EB"));
            return View(babies.ToList());
        }
        public ActionResult VP()
        {
            var vps = db.Products.Where(p => p.Category.Contains("VP"));
            return View(vps.ToList());
        }
        public ActionResult SH()
        {
            var shs = db.Products.Where(p => p.Category.Contains("SH"));
            return View(shs.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new
               HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}