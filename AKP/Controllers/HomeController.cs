using System.Web.Mvc;
using AKP.ViewModels;
using AKP.Infrastructure;
using System.Net;
using Newtonsoft.Json;
using AKP.App_Start;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using AKP.Models;
using System;

namespace AKP.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Administrator"))
                ViewBag.UserIsAdmin = true;
            else
                ViewBag.UserIsAdmin = false;
            return View();
        }

        public ActionResult StaticPages(string pagename)
        {
            return View(pagename);
        }
        public PartialViewResult WeatherGadget()
        {
            WeatherGadgetViewModel model = new WeatherGadgetViewModel();
            var user = UserManager.FindById(User.Identity.GetUserId());
            Person person = user.person;
            WeatherItem weather = GetWeatherApi(person.City);
            model.Temp = weather.main.temp_min.ToString();
            model.City = person.City;
            model.Speed = weather.wind.speed;
            model.Humidity = weather.main.humidity;
            model.Clouds = weather.clouds.all;
            model.Pressure = weather.main.pressure;
            string icon = weather.weather[0].icon;
            model.Picture = GetWeatherSourcePicture(icon);
            return PartialView(model);
        }
        public PartialViewResult ExchangeRateGadget()
        {
            //Lepsze rozwiazanie: pojedyńcze połączenie z api z całą tabelą z wiloma walutami
            ExchangeRateItem eur = GetExchangeRateApi("eur");
            ExchangeRateItem usd = GetExchangeRateApi("usd");
            ExchangeRateItem chf = GetExchangeRateApi("chf");
            ExchangeRateItem gbp = GetExchangeRateApi("gbp");
            ExchangeRateGadgetViewModel model = new ExchangeRateGadgetViewModel()
            {
                EUR = eur.rates[0].mid,
                USD = usd.rates[0].mid,
                CHF = chf.rates[0].mid,
                GBP = gbp.rates[0].mid
            };

            return PartialView(model);
        }
        public WeatherItem GetWeatherApi(string city)
        {
            WebClient webclient = new WebClient();
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric" + Const.ApiWeatherKey);
            string weatherjson = webclient.DownloadString(url);
            WeatherItem weatheritem = JsonConvert.DeserializeObject<WeatherItem>(weatherjson);
            return weatheritem;
        }
        public ExchangeRateItem GetExchangeRateApi(string rate)
        {
                WebClient webclient = new WebClient();
                string url = string.Format("http://api.nbp.pl/api/exchangerates/rates/a/" + rate + "/?format=json");
                string ratejson = webclient.DownloadString(url);
                ExchangeRateItem item = JsonConvert.DeserializeObject<ExchangeRateItem>(ratejson);
                return item;
            
        }
        public string GetWeatherSourcePicture(string item)
        {
            string source = string.Format("~/Content/Img/{0}.png", item);
            return source;
        }
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;

            }
        }
    }
}