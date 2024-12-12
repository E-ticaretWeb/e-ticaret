using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_SHOPPING_WEB_SITE.Identity;
using E_SHOPPING_WEB_SITE.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace E_SHOPPING_WEB_SITE.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;  //kullanıcı yöneticisi
        private RoleManager<ApplicationRole> RoleManager;  // rol yöneticisi

        public AccountController()
        {
            var context = new IdentityDataContext(); // veri tabanıyla bağlantı
            var userStore = new UserStore<ApplicationUser>(context);
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(context);
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                // kullanıcı adı ve e-postayı kontrol ettiğimiz yer, eğer varsa bu bilgilere sahip kullanıcı zaten kayıtlı mesajı dönecek
                var existingUser = UserManager.FindByName(model.Username);
                var existingEmail = UserManager.FindByEmail(model.Email);

                if (existingUser != null)
                {
                    ModelState.AddModelError("", "A user with this username already exists.");
                }
                else if (existingEmail != null)
                {
                    ModelState.AddModelError("", "A user with this email already exists.");
                }
                else
                {
                    // e-mail ve username kayıtlı değilse kullanıcı oluşmaya başlayacak
                    var user = new ApplicationUser
                    {
                        Name = model.Name,    // veritabanına gönderilen veriler
                        Surname = model.Surname,
                        Email = model.Email,
                        UserName = model.Username
                    };

                    IdentityResult result = UserManager.Create(user, model.Password);  // kullanıcı oluşturuluyor

                    if (result.Succeeded)
                    {
                        // varsayılan "user" rolü ekliyoruz burada
                        if (!RoleManager.RoleExists("user"))
                        {
                            RoleManager.Create(new ApplicationRole("user", "Default user role"));
                        }

                        UserManager.AddToRole(user.Id, "user");

                        // Kayıt başarılı mesajını ViewBag ile geç
                        ViewBag.SuccessMessage = "Registration successful! You can now log in.";
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        // başarısızlık durumunda hata mesajı döndür
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error);
                        }
                    }
                }
            }
            return View(model);
        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcıyı kullanıcı adına göre kontrol ediyoruz
                var user = UserManager.FindByName(model.UserName);

                if (user == null) // Kullanıcı adı veritabanında yoksa hata mesajı dönecek
                {
                    ModelState.AddModelError("", "There is no such a user.");
                }
                else
                {
                    // Kullanıcı adı varsa, şifre kontrolü
                    var validUser = UserManager.Find(model.UserName, model.Password);

                    if (validUser == null) // Şifre yanlışsa
                    {
                        ModelState.AddModelError("", "Invalid username or password.");
                    }
                    else
                    {
                        // Kullanıcı adı ve şifre doğruysa oturum aç 
                        var authManager = HttpContext.GetOwinContext().Authentication; // getowin kullanıcıyı tanımamız için özel bir fonksiyon,
                                                                                       // kullanıcının siteye bıraktığı çerezi tutuyor

                        var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = model.RememberMe  // beni hatırla bölümü, kullanıcı bir sonraki girişinde otomatik giriş yaparak geliyor
                        };

                        authManager.SignIn(authProperties, identityclaims);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            
            return View(model);
        }



        public ActionResult Logout()  // oturum kapatma işlemleri
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

    }
}