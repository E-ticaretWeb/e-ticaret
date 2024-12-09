using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_SHOPPING_WEB_SITE.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Surname")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]

        public string Email{ get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required]
        [DisplayName("rePassword")]
        [Compare("Password", ErrorMessage ="Password not match")]
        public string RePassword { get; set; }


    }
}