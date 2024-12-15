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

        // Kategori Menü
        public ActionResult Menu()
        {
            var categories = _context.Categories.Include("SubCategories").ToList();
            return PartialView("CategoryMenu", categories);
        }

        // Kategoriye ait Ürünler
        public ActionResult CategoryProducts(int id)
        {
            var products = _context.Products
                .Where(p => p.SubCategory.CategoryId == id || p.SubCategoryId == id)
                .ToList();

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.SelectedCategoryId = id;
            return View(products);
        }

        // Admin Paneli: Kategori Listeleme
        public ActionResult AdminIndex()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // Yeni Kategori Ekleme (GET)
        public ActionResult AddCategory()
        {
            return View();
        }

        // Yeni Kategori Ekleme (POST)
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("AdminIndex");
            }
            return View(category);
        }

        // Kategori Düzenleme (GET)
        public ActionResult EditCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return HttpNotFound();
            return View(category);
        }

        // Kategori Düzenleme (POST)
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("AdminIndex");
            }
            return View(category);
        }

        // Kategori Silme
        public ActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("AdminIndex");
        }
    }
}


