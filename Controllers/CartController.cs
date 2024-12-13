using E_SHOPPING_WEB_SITE.Entity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace E_SHOPPING_WEB_SITE.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().AddToCart(product, 1);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        // Summary action'ý burada
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
    }
}
