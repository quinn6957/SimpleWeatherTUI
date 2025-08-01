using System.Text.Json.Serialization;

namespace SimpleWeatherTUI
{
    public class WeatherForecast
    {
        public required List<CurrentWeather> Forecasts { get; set; }
    }
    public class CurrentWeather
    {
        public DateTime Time { get; set; }
        public int Temperature { get; set; }
        public int FeelsLike { get; set; }
        public required string TemperatureUnit { get; set; }
        public required string ShortForecast { get; set; }
        public required string DetailedForecast { get; set; }
        public double WindSpeed { get; set; }
        public int Humidity { get; set; }

    }

    public class OpenWeatherMapCurrentWeather
    {
        public long Dt { get; set; }
        public required MainInfo Main { get; set; }
        public required List<WeatherInfo> Weather { get; set; }
        public required WindInfo Wind { get; set; }
        public int Humidity { get; set; }
    }

    public class MainInfo
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
        public int Humidity { get; set; }
    }

    public class WeatherInfo
    {
        public required string Main { get; set; }
        public required string Description { get; set; }

    }

    public class WindInfo
    {
        public double Speed { get; set; }
    }

    // API Response Structure.
    public class ZipcodeApiResponse
    {
        [JsonPropertyName("latitude")]
        public double Lat { get; set; }

        [JsonPropertyName("longitude")]
        public double Lng { get; set; }

        [JsonPropertyName("city")]
        public required string City { get; set; }

        [JsonPropertyName("country_name")]
        public required string Country { get; set; }
    }
}