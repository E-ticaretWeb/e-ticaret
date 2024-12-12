using E_SHOPPING_WEB_SITE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace E_SHOPPING_WEB_SITE.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();

        public ActionResult Index()
        { return View(_context.Products.ToList()); }

        public ActionResult Details(int id)
        {
            var product = _context.Products
                .Include(p => p.SubCategory) // SubCategory'yi dahil ediyoruz
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return HttpNotFound(); // Ürün bulunamazsa 404 döndür
            }

            return View(product);
        }




        public ActionResult About() { return View(); }
        public ActionResult Contact() { return View(); }

    }
}