using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using E_SHOPPING_WEB_SITE.Entity;
using E_SHOPPING_WEB_SITE.Identity;

namespace E_SHOPPING_WEB_SITE
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        { 
            AreaRegistration.RegisterAllAreas();
           E_Shopping_.RouteConfig.RegisterRoutes(RouteTable.Routes);

           Database.SetInitializer(new DataInitializer());
           Database.SetInitializer(new IdentityInitializer());
        }
    }
}
