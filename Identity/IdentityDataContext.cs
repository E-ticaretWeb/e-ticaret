using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_SHOPPING_WEB_SITE.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace E_SHOPPING_WEB_SITE.Identity
{
    public class IdentityDataContext:IdentityDbContext<ApplicationUser>
    {
        IdentityDataContext(): base("dataConnection")
        {
            
        }
    }
}