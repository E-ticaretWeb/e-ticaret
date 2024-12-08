using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using E_SHOPPING_WEB_SITE.Identity;

namespace E_SHOPPING_WEB_SITE.Entity
{
    public class DataContext : DbContext

    {

        public DataContext() : base("DataConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Product> Products { get; set; }


    }

    
}