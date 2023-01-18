using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.Domain.Entities;
using WcfService.Domain.ValueObjects;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WeatherWebService : IWeatherWebService
    {
        private const string OpenWeatherMapApiKey = "get your OpenWeatherMap ApiKey";
        public Root GetWeatherForCity(string cityName)
        {
            City city = new City(cityName);

            using(HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(
                    $"https://api.openweathermap.org/data/2.5/weather?q={city.CityName.Value}&APPID={OpenWeatherMapApiKey}").Result;

                var resposeDeserialized = JsonConvert.DeserializeObject<Root>(response);

                return resposeDeserialized;
            }

        }
    }
}
