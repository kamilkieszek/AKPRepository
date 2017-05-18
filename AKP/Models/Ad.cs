namespace AKP.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using ViewModels;
    public class Ad
    {
        [HiddenInput(DisplayValue = false)]
        public int AdId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText), DisplayName("Treść")]
        public string Content { get; set; }
        [DisplayName("Data Dodania")]
        public DateTime AddTime { get; set; }

        public virtual Person person { get; set; }
    }
}