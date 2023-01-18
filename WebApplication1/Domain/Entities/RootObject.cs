using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplication1.Domain.Entities
{
    public class Root
   {
        public string Name { get; set; }
        public Weather[] Weather { get; set; }   
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
    }
}