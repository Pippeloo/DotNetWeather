// ========================
// Written by: Jules Torfs
// Student number: r0878800
// All rights reserved.
// ========================

// Import Libraries
using Newtonsoft.Json.Linq;

namespace DotNetWeather
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Setups the API Key
            var api_key = "fd0f221dcbc5cce7a9d7a2f832156646";

            while (true)
            {
                Console.WriteLine("*--=========================--*");
                Console.WriteLine("Welcome to the weather app!");
                // Ask the user for the city
                var locationName = AskCity();

                Console.WriteLine("-------------------------------");
                Console.WriteLine($"Getting weather for {locationName}");

                // Get the weather for the city
                var data = await GetWeather(locationName, api_key);

                // Check if the data is valid
                if (data == "")
                {   
                    // Not valid, exit the program
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Sorry, we couldn't find that city.");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Please try again.");
                    Console.WriteLine("===============================");
                    Console.WriteLine("Press any key to exit.");
                    // Wait for the user to press a key
                    Console.ReadKey();
                    return;
                }
                else
                {
                    // Valid, parse the data as a JSON object
                    var json = JObject.Parse(data);

                    // Extract the data from the JSON object
                    var weather = json["weather"][0]["main"].ToString();
                    var tempCelcius = json["main"]["temp"].ToString();
                    var windSpeed = json["wind"]["speed"].ToString();
                    var humidity = json["main"]["humidity"].ToString();

                    // Print the data
                    Console.WriteLine($"The weather is {weather}");
                    Console.WriteLine($"The temperature is {tempCelcius}°C");
                    Console.WriteLine($"The wind speed is {windSpeed}m/s");
                    Console.WriteLine($"The humidity is {humidity}%");
                    Console.WriteLine("*--=========================--*");
                    // Ask if the user wants to try again
                    Console.WriteLine("Do you want to try again? (y/n)");
                    var input = Console.ReadKey();

                    // Check if the user pressed Y or Enter
                    if (input.Key != ConsoleKey.Y && input.Key != ConsoleKey.Enter)
                    {
                        return;
                    }
                    // Write a new line to start separating the output
                    Console.WriteLine();
                }
            }
        }

        private static async Task<String> GetWeather(string location_name, string key)
        {
            // Create a new HTTP client to do http requests
            var httpClient = new HttpClient();
            // Define the url that has to be called
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={location_name}&limit=1&units=metric&appid={key}";
            // Get the status code of the response
            var response = await httpClient.GetAsync(url);

            // Check if the response is valid
            if (response.IsSuccessStatusCode)
            {   
                // Valid, get the response data
                String data = await response.Content.ReadAsStringAsync();
                // Return the data
                return data;
            }
            else
            {
                // Not valid, return an empty string
                return "";
            }
        }

        private static String AskCity()
        {
            while (true)
            {
                Console.Write("Enter the city name: ");
                // Ask the user for the city
                var locationName = Console.ReadLine();
                // Check if the user entered a city
                if (locationName == null || locationName == "")
                {
                    // Not valid, ask again
                    Console.WriteLine("Please enter a valid city name.");
                }
                else
                {
                    // Valid, return the city name
                    return locationName;
                }
            }
        }
    }
}