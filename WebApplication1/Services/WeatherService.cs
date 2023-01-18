using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using System.Xml;
using WebApplication1.Domain.Entities;
using Newtonsoft.Json;

namespace WebApplication1.Services
{
    public interface IWeatherClient
    {
        Root GetWeatherForCity(City city);
    }
    public class WeatherService : IWeatherClient
    {
        private const string OpenWeatherMapApiKey = "get your OpenWeatherMap Api Key";
        private readonly IHttpClientFactory _httpClient;

        public WeatherService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public Root GetWeatherForCity(City city)
        {
            try
            {
                var client = _httpClient.CreateClient("weatherApi");

                var response = client.GetStringAsync(
                    $"weather?q={city.CityName.Value}&APPID={OpenWeatherMapApiKey}").Result;

                var resposeDeserialized = JsonConvert.DeserializeObject<Root>(response);

                return resposeDeserialized;

            }
            catch (Exception)
            {
                throw new Exception("Error, desde WeatherService");
            }
        }
    }
}