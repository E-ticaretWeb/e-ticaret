using E_SHOPPING_WEB_SITE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace E_SHOPPING_WEB_SITE.Controllers
{
    public class HomeController : Controller
    {
       DataContext _context = new DataContext();

        public ActionResult Index()
        { return View(_context.Products.ToList()); }

        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i=>i.Id==id).FirstOrDefault());
        }




        public ActionResult About() { return View(); }
        public ActionResult Contact() { return View(); }

    }
}