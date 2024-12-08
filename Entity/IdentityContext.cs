using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_SHOPPING_WEB_SITE.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace E_SHOPPING_WEB_SITE.Entity
{
    public class IdentityDataContext: IdentityDbContext<ApplicationUser>

    {
        public IdentityDataContext() : base("DefaultConnection")
        {

        }
    }
}