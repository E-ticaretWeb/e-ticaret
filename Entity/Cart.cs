using E_SHOPPING_WEB_SITE.Entity;
using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace E_SHOPPING_WEB_SITE.Entity
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();

        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }

        public void AddProduct(Product product, int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.Id == product.Id);

            if (line == null)
            {
                _cartLines.Add(new CartLine() { Product = product, Quantity = 1 });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(i => i.Product.Id == product.Id);
        }

        public double Total()
        {
            return _cartLines.Sum(i => i.Product.Price * i.Quantity);
        }

        public void Clear()
        {
            _cartLines.Clear();
        }

        internal void AddToCart(object product, int quantity)
        {
            throw new NotImplementedException();
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}