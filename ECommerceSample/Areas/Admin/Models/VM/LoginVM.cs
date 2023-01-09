using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceSample.Areas.Admin.Models.VM
{
    public class LoginVM
    {
        [
            EmailAddress(ErrorMessage = "E-Posta formatında giris yapiniz"),
            Required(ErrorMessage = "E-Posta Giriniz"),
            DisplayName("E-Posta")
        ]
        public string Email { get; set; }
        [
            Required(ErrorMessage = "Parola Giriniz"),
            DisplayName("Parola")
        ]
        public string Password { get; set; }

        [DisplayName("Beni Hatirla")]
        public bool IsPersistant { get; set; }
    }
}