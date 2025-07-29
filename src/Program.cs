using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using dotenv.net;
using Spectre.Console;

namespace SimpleWeatherTUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var title = new Rule("simple weather tui");

            var table = new Table().Centered();
            table.ShowFooters();
            var ipAddress = IPGeoHelper.GetPublicIP().GetAwaiter().GetResult();
            var coordinates = IPGeoHelper.GetGeolocation(ipAddress);

            if (coordinates != null)
            {
                // The latitude and longitude used from 
                double latitude = coordinates.Item1;
                double longitude = coordinates.Item2;

                CurrentWeather weather = await WeatherService.GetWeatherDataAsync(latitude, longitude); // Get current weather


                // Area where the actual code (post-ZIP code and weather fetching) is.
                if (weather != null)
                {
                    AnsiConsole.Clear();
                    AnsiConsole.Write(title);
                    var LocationBanner = new Rule("[paleturquoise4]Weather information for " + coordinates.Item3 + ", " + coordinates.Item4 + "[/]\n");
                    LocationBanner.Justification = Justify.Center;
                    AnsiConsole.Write(LocationBanner);
                    table.Border = TableBorder.MinimalHeavyHead;
                    // Table Containing the conditions...
                    table.AddColumn("Current Conditions");
                    table.AddColumn("Extra Details");
                    table.AddRow($"[bold]{weather.ShortForecast} ({weather.DetailedForecast})[/]", $"Temp: {weather.Temperature}{weather.TemperatureUnit}\nFeels Like: {weather.FeelsLike}{weather.TemperatureUnit}\nHumidity: {weather.Humidity}%\nWind Speed: {weather.WindSpeed} mph");
                    AnsiConsole.Write(table);
                    var DateFooter = new Rule("[paleturquoise4 dim]Requested at " + TimeConvert.FormatDateTime(weather.Time) + "[/]");
                    DateFooter.Justification = Justify.Center;
                    AnsiConsole.Write(DateFooter);

                }
            }
        }
    }
}