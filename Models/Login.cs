using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace E_SHOPPING_WEB_SITE.Models
{
    public class Login
    {
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        

        public string Password { get; set; }
        [Required]
        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }

    }
}