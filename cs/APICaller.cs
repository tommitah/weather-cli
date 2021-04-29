using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherNator9000 {
  class APICaller {
    private static readonly APICaller instance = new APICaller();

    static APICaller() {}
    private APICaller() {}
    public static APICaller Instance {
      get {
        return instance;
      }
    }

    public static async Task<WeatherData> GetForecast(string url) {
      try {
        using(HttpClient client = new HttpClient()) {
          using(HttpResponseMessage res = await client.GetAsync(url)) {
            using(HttpContent content = res.Content) {
              var data = await content.ReadAsStringAsync();
              if (content != null) {
                // dynamic -> resolved at runtime! NOT efficient.
                var dataJson = JsonConvert.DeserializeObject<dynamic>(data);
                var weatherData = new WeatherData(
                    main:  $"{dataJson.weather[0].main}",
                    temp:  $"{dataJson.main.temp}",
                    humty: $"{dataJson.main.humidity}"
                  );
                return weatherData;
              }
              else Console.WriteLine("ooop no data");
              return null;
            }
          }
        }
      } catch(Exception exception) {
        Console.WriteLine(exception.Message.ToString());
        throw exception;
      }
    }
  }
}
