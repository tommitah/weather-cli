using System;
using System.Threading.Tasks;

namespace WeatherNator9000 {
  class Program {
    static void Main(string[] args) {
      MainAsync(args).GetAwaiter().GetResult();
    }

    // MainAsync, so we can call async methods.
    static async Task MainAsync(string[] args) {
      var apiKey = new APIKey();
      string location;

      Console.WriteLine("SEND LOCATION: ");
      location = Console.ReadLine();
      if(location == "") {
        Console.WriteLine("is not a valid search argument.");
        return;
      }

      var weather = await APICaller.GetForecast(
          apiKey.UrlStart + location + apiKey.UrlEnd
        );

      if(weather != null)
        Console.Write($"Weather in {location}: \n\t{weather.Main} \n\t{weather.Temperature} Celsius \n\t{weather.Humidity} %");
      else Console.WriteLine("Nothing here.");
    }
  }
}
