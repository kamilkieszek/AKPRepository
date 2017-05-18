using System.Web.Mvc;

namespace AKP.Models
{
    public class Holiday
    {
        [HiddenInput(DisplayValue = false)]
        public int HolidayId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }
        public int NrOfDays { get; set; }
        public int DaysToUse { get; set; }
        public int DaysSpend { get; set; }

        public virtual Person person { get; set; }
    }
}