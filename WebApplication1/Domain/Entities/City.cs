using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Domain.ValueObjects;

namespace WebApplication1.Domain.Entities
{
    public class City
    {
        public City(string cityName)
        {
            CityName = Name.Create(cityName);
        }
        public Name CityName { get; private set; }
    }
}