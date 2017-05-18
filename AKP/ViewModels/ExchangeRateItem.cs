using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.ViewModels
{
    public class ExchangeRateItem
    {
        public string table { get; set; }
        public string currency { get; set; }
        public string code { get; set; }
        public Rates[] rates { get; set; }
    }
    public class Rates
    {
        public string no { get; set; }
        public DateTime effectiveDate { get; set; }
        public float mid { get; set; }
    }
}