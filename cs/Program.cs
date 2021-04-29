using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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

      var weather = await APICaller.GetForecast(
          apiKey.UrlStart + location + apiKey.UrlEnd
        );

      Console.WriteLine(weather.Main);
      Console.WriteLine(weather.Temperature);
      Console.WriteLine(weather.Humidity);

      Console.Write( $"Weather in {location}: \n\t{weather.Main} \n\t{weather.Temperature} Celsius \n\t{weather.Humidity} %");
    }
  }
}
