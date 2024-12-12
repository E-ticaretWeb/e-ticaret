using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace E_SHOPPING_WEB_SITE.Entity
{
    public class DataContext : DbContext

    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }



        public DataContext() : base("DefaultConnection") // bağlama işlemi
        {
            
        }

    }
}