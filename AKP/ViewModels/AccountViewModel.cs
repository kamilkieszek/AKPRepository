using AKP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AKP.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage ="Wprowadź adres e-mail!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Wprowadź hasło!")]
        [Display(Name = "Hasło")]
        [StringLength(15, ErrorMessage = "Hasło musi składać się z conajmniej {2} znaków!", MinimumLength = 5)]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
    public class RegisterViewModel
    {
        public virtual Person person { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(15,ErrorMessage ="Hasło musi składać się z conajmniej {2} znaków!", MinimumLength = 5)]
        [Display(Name = "Hasło")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Potwierdź hasło")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasło oraz potwierdzenie nie pasują do siebie!")]
        public string ConfirmPassword { get; set; }

    }
}