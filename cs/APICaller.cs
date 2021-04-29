using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherNator9000 {
  class APICaller {
    // thread safe singleton.
    private static readonly APICaller instance = new APICaller();

    static APICaller() {}
    private APICaller() {}
    public static APICaller Instance {
      get {
        return instance;
      }
    }

    // Pings the API, reads the response and returns a WeatherData object from GetWeatherData
    public static async Task<WeatherData> GetForecast(string url) {
      try {
        using(HttpClient client = new HttpClient()) {
          using(HttpResponseMessage res = await client.GetAsync(url)) {
            using(HttpContent content = res.Content) {
              var data = await content.ReadAsStringAsync();
              if (content != null) {
                // dynamic -> resolved at runtime! NOT efficient.
                return GetWeatherData(data);
              }
              else Console.WriteLine("ooop no data");
              return null;
            }
          }
        }
      } catch(Exception exception) {
        Console.WriteLine(exception.Message.ToString());
        throw;
      }
    }

    // Deserializes the response string into Json and returns a WeatherData object
    private static WeatherData GetWeatherData(string jsonStr) {
      var dataJson = JsonConvert.DeserializeObject<dynamic>(jsonStr);
      return new WeatherData(
          main:  $"{dataJson.weather[0].main}",
          temp:  $"{dataJson.main.temp}",
          humty: $"{dataJson.main.humidity}"
        );
    }
  }
}
