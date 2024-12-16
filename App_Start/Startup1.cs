using System;
using System.Globalization;
using System.Threading;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(E_SHOPPING_WEB_SITE.App_Start.Startup1))]

namespace E_SHOPPING_WEB_SITE.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // Dolar cinsinden fiyat göstermek için genel kültür ayarı
            var usCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = usCulture;
            Thread.CurrentThread.CurrentUICulture = usCulture;

            // Cookie Authentication
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login")
            });

            // Eğer tüm uygulama genelinde kültür ayarını tutmak isterseniz
            CultureInfo.DefaultThreadCurrentCulture = usCulture;
            CultureInfo.DefaultThreadCurrentUICulture = usCulture;

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
