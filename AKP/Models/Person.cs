using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKP.Models
{
    public class Person
    {
        [ScaffoldColumn(false)]
        public int PersonId { get; set; }
        [DisplayName("Administrator")]
        public bool Admin { get; set; }
        [DisplayName("Imię")]
        [Required(ErrorMessage ="Wprowadź imię pracownika")]
        public string Name { get; set; }
        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Wprowadź nazwisko pracownika")]
        public string Surname { get; set; }
        [DisplayName("Pesel")]
        [Required(ErrorMessage = "Wprowadź pesel pracownika. Musi zawierać 11 znaków!")]
        public long IndividualNumber { get; set; }
        [DisplayName("Miasto")]
        [Required(ErrorMessage = "Wprowadź miasto zamieszkania pracownika")]
        public string City { get; set; }
        [DisplayName("Ulica")]
        [Required(ErrorMessage = "Wprowadź ulicę")]
        public string Street { get; set; }
        [DisplayName("Numer domu/mieszkania")]
        [Required(ErrorMessage = "Wprowadź numer domu/mieszkania")]
        public int StreetNr { get; set; }
        [DisplayName("Kod pocztowy")]
        [Required(ErrorMessage = "Wprowadź kod pocztowy")]
        public string PostalCode { get; set; }
        [DisplayName("Numer telefonu")]
        [Required(ErrorMessage = "Wprowadź numer telefonu")]
        public int TelNumber { get; set; }
        [DisplayName("Stanowisko")]
        [Required(ErrorMessage = "Wprowadź stanowisko")]
        public string Appointment { get; set; }
        [DisplayName("Płeć")]
        [Required(ErrorMessage = "Wprowadź płeć")]
        public string Sex { get; set; }
        [DisplayName("Data zatrudnienia")]
        [ScaffoldColumn(false)]
        public DateTime DateOfEmployment { get; set; }
        [Range(1.00, 3.00, ErrorMessage= "Wartość musi mieścić się w przedziale od 1 do 3!")]
        [DisplayName("Grupa dochodowa")]
        [Required(ErrorMessage = "Wprowadź grupę dochodową")]
        public int IncomeGroup { get; set; }
        [DisplayName("Wykształcenie")]
        [Required(ErrorMessage = "Wprowadź wykształcenie pracownika")]
        public string Education { get; set; }

        public virtual ICollection<Holiday> holidays { get; set; }
        public virtual ICollection<Salary> salary { get; set; }
        public virtual ICollection<Message> message { get; set; }
        public virtual ICollection<Ad> ad { get; set; }
    }
}