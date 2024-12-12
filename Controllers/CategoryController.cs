using E_SHOPPING_WEB_SITE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_SHOPPING_WEB_SITE.Controllers
{
    public class CategoryController : Controller
    {
        private DataContext _context = new DataContext();

        public ActionResult Menu()
        {
            var categories = _context.Categories.Include("SubCategories").ToList();
            return PartialView("CategoryMenu", categories);
        }



        public ActionResult CategoryProducts(int id)
        {
            var products = _context.Products
                .Where(p => p.SubCategory.CategoryId == id || p.SubCategoryId == id) // Hem CategoryId hem SubCategoryId kontrolü
                .ToList();

            ViewBag.Categories = _context.Categories.ToList(); // Tüm kategoriler
            ViewBag.SelectedCategoryId = id; // Seçili kategori
            return View(products);
        }




    }
}



