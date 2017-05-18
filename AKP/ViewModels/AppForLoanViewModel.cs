using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AKP.ViewModels
{
    public class AppForLoanViewModel
    {
        [DataType(DataType.MultilineText)]
        public string Target { get; set; }
        [DataType(DataType.MultilineText)]
        public string Guarantor { get; set; }
        [Range(10,40, ErrorMessage ="Ilość rat musi mieścić się w przedziale od 10 do 40!")]
        public int AmountOfInstallments { get; set; }
        [Range(1000.00, 5000.00, ErrorMessage = "Wielkość pożyczki musi mieścić się w przedziale od 1000 do 5000 zł.!")]
        public int AmountOfLoan { get; set; }
    }
}