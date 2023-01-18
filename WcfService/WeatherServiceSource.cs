using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWeatherWebService
    {
        [OperationContract]
        Root GetWeatherForCity(string cityName);
    }

    [DataContract]
    public class Root
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Weather[] Weather { get; set; }
    }

    [DataContract]
    public class Weather
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Main { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
