using Microsoft.Extensions.DependencyInjection;
using System;
using System.Web.Services;
using WebApplication1.Configuration;
using WebApplication1.Domain.Entities;
using WebApplication1.Services;

namespace WebApplication1
{
    /// <summary>
    /// Descripción breve de WS_Clima
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Clima : System.Web.Services.WebService
    {
        private ServiceProvider _provider;
        public WS_Clima()
        {
            this.GenerateServiceCollection();
        }

        public void GenerateServiceCollection()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient("weatherApi", client =>
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            });

            //extension method
            serviceCollection.AddWeatherService();

            _provider = serviceCollection.BuildServiceProvider();

        }
        

        /// <summary>
        /// metodo encargado de obtener el clima de la ciudad que se le indique por parametro
        /// 
        /// </summary>
        /// <param name="nombreCiudad"></param>
        [WebMethod]
        public Root GetWeatherForCity(string nombreCiudad)
        {
            try
            {
                City ciudad = new City(nombreCiudad);
                var referenceToService = _provider.GetService<IWeatherClient>();
                return referenceToService.GetWeatherForCity(ciudad);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}
