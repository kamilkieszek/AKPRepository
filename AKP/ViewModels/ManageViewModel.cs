using AKP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AKP.ViewModels
{
    public class ManageViewModel
    {
        public class ManageCredentialsViewModel
        {
            public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
            public Controllers.ManageController.ManageMessageId? Message { get; set; }
            public Person person { get; set; }
        }
        public class ChangePasswordViewModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Aktualne hasło:")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(15, ErrorMessage = "Hasło musi składać się z conajmniej {2} znaków!", MinimumLength = 5)]
            [DataType(DataType.Password)]
            [Display(Name = "Nowe hasło:")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potwierdź nowe hasło:")]
            [Compare("NewPassword", ErrorMessage = "Hasło oraz potwierdzenie nie pasują do siebie!")]
            public string ConfirmPassword { get; set; }
        }
    }
}