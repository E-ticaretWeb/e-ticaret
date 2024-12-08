using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_SHOPPING_WEB_SITE
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
           E_Shopping_.RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
