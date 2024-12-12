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

        public string Image { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public bool isApproved { get; set; }

        public int SubCategoryId { get; set; }  // FOREIGN KEY
        public SubCategory SubCategory { get; set; }



    }
}