using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AKP.ViewModels
{
    public class HolidayViewModel
    {
        [Required(ErrorMessage = "Musisz wypełnić pole: Ilość dni urlopu!")]
        [Range(1, int.MaxValue, ErrorMessage = "Ilość dni urlopu musi być liczbą większą od 0 !")]
        public int AmountOfDay { get; set; }
        [Required(ErrorMessage = "Musisz wporowadzić datę początku i końca urlopu!")]
        public DateTime From { get; set; }
        [Required(ErrorMessage = "Musisz wporowadzić datę początku i końca urlopu!")]
        public DateTime To { get; set; }
    }
}