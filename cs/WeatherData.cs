namespace WeatherNator9000
{
    public readonly struct WeatherData
    {
        public string Main { get; }
        public string Temperature { get; }
        public string Humidity { get; }

        public WeatherData(string main, string temp, string humty)
        {
            Main = main;
            Temperature = temp;
            Humidity = humty;
        }
    }
}
