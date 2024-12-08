using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_SHOPPING_WEB_SITE.Entity
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public bool isApproved { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }


    }
}