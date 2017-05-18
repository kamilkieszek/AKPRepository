using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.ViewModels
{
    public class WeatherGadgetViewModel
    {
        public string City { get; set; }
        public string Temp { get; set; }
        public string Speed { get; set; }
        public int Humidity { get; set;}
        public int Clouds { get; set; }
        public float Pressure { get; set; }
        public string Picture { get; set; }
    }
}