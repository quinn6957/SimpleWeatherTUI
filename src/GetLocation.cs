using Spectre.Console;
using dotenv.net;
using System.Net.Http.Json;
using System.Text.Json;

namespace SimpleWeatherTUI
{
    public class GetLocation
    {
        private static readonly HttpClient client = new();


        public static async Task<string> GetPublicIP()
        {
            using var httpClient = new HttpClient();
            var ip = await httpClient.GetStringAsync("https://icanhazip.com");
            return ip.Trim();
        }

        public static async Task<Tuple<double, double, string, string>> GetCoordinatesFromIP(string ip)
        {
            DotEnv.Load(); // Load environment variables from .env file
            var envVars = DotEnv.Read();
            // THIS API KEY IS REDACTED. REPLACE WITH YOUR OWN.
            string geocodingKey = envVars["IPGEO_APIKEY"];

            // API to get latitude and longitude data from IP address
            string geocodingUrl = $"https://api.ipgeolocation.io/ipgeo?apiKey={geocodingKey}&ip={ip}";
            try
            {
                var response = await client.GetAsync(geocodingUrl);
                AnsiConsole.Markup($"[gray]LOG: [/]Getting coordinate information for \"{ip}\"... ");
                response.EnsureSuccessStatusCode(); // Check for successful response                

                var geocodingData = await response.Content.ReadFromJsonAsync<ZipcodeApiResponse>();

                if (geocodingData != null)
                {
                    AnsiConsole.Markup("[green bold]SUCCESS[/]\n");
                    return Tuple.Create(geocodingData.Lat, geocodingData.Lng, geocodingData.City, geocodingData.Country);
                }
                else
                {
                    AnsiConsole.Markup("[red bold]FAILURE[/]\n");

                    AnsiConsole.MarkupLine($"[bold red]Could not find coordinates for IP Address: {ip}[/]");
                    throw new ApplicationException();
                }
            }
            catch (HttpRequestException ex)
            {
                AnsiConsole.Markup("[red bold]FAILURE[/]\n");
                AnsiConsole.MarkupLine($"[bold red]Geocoding API Error: {ex.Message}[/]");
                throw new HttpRequestException();
            }
            catch (JsonException ex)
            {
                AnsiConsole.Markup("[red bold]FAILURE[/]\n");
                AnsiConsole.MarkupLine($"[bold red]Error parsing JSON response: {ex.Message}[/]");
                throw new JsonException();
            }
            catch (Exception ex)
            {
                AnsiConsole.Markup("[red bold]FAILURE[/]\n");
                AnsiConsole.MarkupLine($"[bold red]An error occurred: {ex.Message}[/]");
                throw new Exception();
            }
        }

    }
}