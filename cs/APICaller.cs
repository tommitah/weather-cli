using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherNator9000 
{
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

    // Pings the API, reads the response and returns a WeatherData struct from GetWeatherData
    public static async Task<WeatherData> GetForecast(string url) {
      try {
        using(var client = new HttpClient()) {
          using(var res = await client.GetAsync(url)) {
            using(var content = res.Content) {
              var data = await content.ReadAsStringAsync();
              // dynamic -> resolved at runtime! NOT efficient.
              return GetWeatherData(data);
            }
          }
        }
      } catch(Exception exception) {
        Console.WriteLine(exception.Message.ToString());
        throw;
      }
    }

    // Deserializes the response string into Json and returns a WeatherData struct.
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
