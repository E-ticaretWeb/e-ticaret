using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_SHOPPING_WEB_SITE.Entity
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<Product> Products { get; set; }

    }
}