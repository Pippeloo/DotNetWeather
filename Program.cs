using System;
using System.Net.Http;
using System.Threading.Tasks;
// include the library for HttpClientFactory



namespace DotNetWeather // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClientFactory.Create();

            var url = "http://api.openweathermap.org/data/2.5/weather?q=London,uk&appid=b1b15e88fa797225412429c1c50c122a1";
            var data = await httpClient.GetStringAsync(url);

            Console.WriteLine(data);

            Console.WriteLine("Hello World!");
            // do a http request to get the weather

        }
    }
}