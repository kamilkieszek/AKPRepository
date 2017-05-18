using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKP.ViewModels
{
    public class AppForPayViewModel
    {
        public enum PeriodListEnum
        {
            Miesiąc,
            Kwartał,
            Rok
        }
        public enum RateEnum
        {
            Netto,
            Brutto
        }
    }
}