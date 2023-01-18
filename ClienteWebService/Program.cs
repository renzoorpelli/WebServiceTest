using System.Text;

namespace ClienteWebService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (WeatherWS.WeatherWebServiceClient client = new WeatherWS.WeatherWebServiceClient())
            {
                var ciudad = client.GetWeatherForCityAsync("London,uk").Result;

                StringBuilder sb = new StringBuilder();
                sb.Append("CLIMA EN ");
                sb.Append(ciudad.Name);

                sb.AppendLine(ciudad.Weather.First().Description);
                sb.AppendLine(ciudad.Weather.First().Main);

                Console.WriteLine(sb.ToString());

            }
        }
    }
}