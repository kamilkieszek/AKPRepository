using AKP.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace AKP.Infrastructure
{
    public class IApiWeatherManager : IApiRepository<WeatherItem>
    {
        public WeatherItem GetApi()
        {
            WebClient webclient = new WebClient();
            string url = string.Format("api.openweathermap.org/data/2.5/weather?q=Toruń" + Const.ApiWeatherKey);
            string weatherjson = webclient.DownloadString(url);
            WeatherItem weatheritem = JsonConvert.DeserializeObject<WeatherItem>(weatherjson);
            return weatheritem;
        }

        public WeatherItem GetApi(string city)
        {
            WebClient webclient = new WebClient();
            string url = string.Format("api.openweathermap.org/data/2.5/weather?q={0}{1}", city, Const.ApiWeatherKey);
            string weatherjson = webclient.DownloadString(url);
            WeatherItem weatheritem = JsonConvert.DeserializeObject<WeatherItem>(weatherjson);
            return weatheritem;
        }
    }
}