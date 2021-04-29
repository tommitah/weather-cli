using System;

namespace WeatherNator9000 {
  public class WeatherData {
    public string Main { get; set; }
    public string Temperature { get; set; }
    public string Humidity { get; set; }

    public WeatherData(string main, string temp, string humty) {
      Main = main;
      Temperature = temp;
      Humidity = humty;
    }
  }
}
