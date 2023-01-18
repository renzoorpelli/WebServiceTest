using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Services;

namespace WebApplication1.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWeatherService(this IServiceCollection services)
        {
            services.AddSingleton<IWeatherClient, WeatherService>();
            return services;
        }

    }
}