using System;
using System.Threading.Tasks;

namespace WeatherNator9000 {
  class Program {
    static void Main(string[] args) {
      MainAsync(args).GetAwaiter().GetResult();
    }

    static async Task MainAsync(string[] args) {
      var apiKey = new APIKey();
      string location;

      Console.WriteLine("SEND LOCATION: ");
      location = Console.ReadLine();

      WeatherData weather = await APICaller.GetForecast(
          apiKey.UrlStart + location + apiKey.UrlEnd
        );

      Console.Write( $"Weather in {location}: \n\t{weather.Main} \n\t{weather.Temperature} Celsius \n\t{weather.Humidity} %");
    }
  }
}
