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
            var api_key = "fd0f221dcbc5cce7a9d7a2f832156646";

            Console.WriteLine("===============================");
            Console.WriteLine("Welcome to the weather app!");

            var locationName = AskCity();

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Getting weather for {locationName}");

            var data = await GetWeather(locationName, api_key);

            if (data == "")
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Sorry, we couldn't find that city.");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Please try again.");
                Console.WriteLine("===============================");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }

            var json = JObject.Parse(data);
            var weather = json["weather"][0]["main"].ToString();
            var tempCelcius = json["main"]["temp"].ToString();
            var windSpeed = json["wind"]["speed"].ToString();
            var humidity = json["main"]["humidity"].ToString();


            Console.WriteLine($"The weather is {weather}");
            Console.WriteLine($"The temperature is {tempCelcius}°C");
            Console.WriteLine($"The wind speed is {windSpeed}m/s");
            Console.WriteLine($"The humidity is {humidity}%");
            Console.WriteLine("===============================");
        }

        private static async Task<String> GetWeather(string location_name, string key)
        {
            var httpClient = new HttpClient();

            var url = $"https://api.openweathermap.org/data/2.5/weather?q={location_name}&limit=1&units=metric&appid={key}";
            var data = await httpClient.GetStringAsync(url);

            var data_json = JObject.Parse(data);

            if (data_json["cod"].ToString() == "200")
            {
                return data;
            }
            else
            {
                Console.WriteLine("Error");
                return "";
            }
        }

        private static String AskCity()
        { 
            while (true) {
                Console.Write("Enter the city name: ");
                var locationName = Console.ReadLine();
                if (locationName == null || locationName == "")
                {
                    Console.WriteLine("Please enter a valid city name.");
                }
                else
                {
                    return locationName;
                }
            }
        }
    }
}