using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
// include the library for HttpClientFactory



namespace DotNetWeather // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var lat = "51.16557";
            var lon = "4.98917";
            var api_key = "fd0f221dcbc5cce7a9d7a2f832156646";

            var data = await GetWeather(lat, lon, api_key);

            var json = JObject.Parse(data);

            Console.WriteLine(json["coord"]["lon"]);
            // do a http request to get the weather
        }

        private static async Task<String> GetWeather(string lat, string lon, string api_key)
        {
            var httpClient = new HttpClient();

            var url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={api_key}";
            var data = await httpClient.GetStringAsync(url);

            return data;
        }
    }
}