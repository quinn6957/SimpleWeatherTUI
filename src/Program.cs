
using SimpleWeatherTUI;
using Spectre.Console;

namespace SimpleWeaherTUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Title Text
            var title = new Rule("[cyan bold]Simple Weather TUI[/]\n");
            title.Justification = Justify.Center;
            var ip = await GetLocation.GetPublicIP(); // Get public IP address
            AnsiConsole.Clear();
            AnsiConsole.Write(title);
            var coordinates = await GetLocation.GetCoordinatesFromIP(ip);
            var table = new Table().Centered();
            table.ShowFooters();

            if (coordinates != null)
            {
                // The latitude and longitude used from 
                double latitude = coordinates.Item1;
                double longitude = coordinates.Item2;

                CurrentWeather weather = await GetForecast.GetCurrentWeatherAsync(latitude, longitude); // Get current weather


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
                    table.AddRow($"[bold]Conditions: \nTemperature: \nFeels Like: \nHumidity: \nWind Speed:[/]", 
                                 $"{weather.ShortForecast} ({weather.DetailedForecast})\n{weather.Temperature}{weather.TemperatureUnit}\n{weather.FeelsLike}{weather.TemperatureUnit}\n{weather.Humidity}%\n{weather.WindSpeed} mph");
                    AnsiConsole.Write(table);
                    var DateFooter = new Rule("[paleturquoise4 dim]Requested at " + TimeConvert.FormatDateTime(weather.Time) + "[/]");
                    var IPFooter = new Rule("[paleturquoise4 dim]IP Address: " + ip + "[/]");
                    DateFooter.Justification = Justify.Center;
                    AnsiConsole.Write(DateFooter);

                }
            }
        }
    }
}