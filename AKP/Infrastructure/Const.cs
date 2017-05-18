using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKP.Infrastructure
{
    public class Const
    {
        public const string ApiWeatherKey = "&APPID=d0386ebd7b802390fc9f63f798fa69a8";
        public static IEnumerable<SelectListItem> CommunicationType = new[]
        {
            new SelectListItem { Value = "1", Text= "Zaświadczenie o wynagrodzeniu" },
            new SelectListItem { Value = "2", Text= "Zaświadczenie o zatrudnieniu" },
            new SelectListItem { Value = "3", Text= "Zaświadczenie o niekorzystaniu z opieki na dziecko" },
            new SelectListItem { Value = "4", Text= "Wniosek o urlop" },
            new SelectListItem { Value = "5", Text= "Wniosek o pożyczkę zakładową" }
        };
        public static IEnumerable<SelectListItem> PeriodList = new[]
        {
            new SelectListItem { Value = "1", Text= "Miesiąc" },
            new SelectListItem { Value = "2", Text= "Kwartał" },
            new SelectListItem { Value = "3", Text= "Rok" },
        };
        public enum PeriotList
        {
            Miesiąc,
            Kwartał,
            Rok
        }
        public enum Rate
        {
            Netto,
            Brutto
        }
        public const double FactorLoanShort = 1.05;
        public const double FactorLoanHigh = 1.1;
    }
}