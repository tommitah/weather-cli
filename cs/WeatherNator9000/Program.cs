using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherNator9000 {
  public class WeatherData {
    public string Weather { get; set; }
    public float Temperature { get; set; }
    public int Humidity { get; set; }

    public WeatherData(string weather, float temp, int humty) {
      Weather = weather;
      Temperature = temp;
      Humidity = humty;
    }
  }

  class Program {
    static void Main(string[] args) {
      GetWeatherData("http://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=cc2928d46d101dbdb1a0e1b6b9af5e54");
    }

    public static async void GetWeatherData(string url) {
      try {
        using(HttpClient client = new HttpClient()) {
          using(HttpResponseMessage res = await client.GetAsync(url)) {
            using(HttpContent content = res.Content) {
              var data = await content.ReadAsStringAsync();
              if (data != null) Console.WriteLine(data);
              else Console.WriteLine("ooops no data soz");
            }
          }
        }
      } catch(Exception exception) {
        Console.WriteLine(exception);
      }
    } 
  }

}
