using HttpClient = System.Net.Http.HttpClient;
using dotenv.net;


namespace SimpleWeatherTUI
{
    public static class IPGeoHelper
    {

        public static async Task<string> GetPublicIP()
        {
            using var httpClient = new HttpClient();
            var ip = await httpClient.GetStringAsync("https://icanhazip.com");
            return ip.Trim();
        }

        public static Tuple<double, double, string, string> GetGeolocation(string ip)
        {
            DotEnv.Load();
            var envVars = DotEnv.Read();

            var apiKey = envVars["IPGEO_APIKEY"];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception("IPGEO_APIKEY environment variable is not set.");
            }

            using var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync($"https://api.ipgeolocation.io/ipgeo?apiKey={apiKey}&ip={ip}").GetAwaiter().GetResult();
            // parse the json response to get the city and country_name fields
            var json = System.Text.Json.JsonDocument.Parse(response);
            double? latitude = null;
            double? longitude = null;
            if (json.RootElement.TryGetProperty("latitude", out var latElem) && latElem.TryGetDouble(out var latVal))
            {
                latitude = latVal;
            }
            if (json.RootElement.TryGetProperty("longitude", out var lonElem) && lonElem.TryGetDouble(out var lonVal))
            {
                longitude = lonVal;
            }
            if (latitude == null || longitude == null)
            {
                throw new Exception("Could not retrieve latitude and/or longitude from the response.");
            }
            string city = json.RootElement.GetProperty("city").GetString();
            string country = json.RootElement.GetProperty("country_name").GetString();
            return Tuple.Create(latitude.Value, longitude.Value, city, country);
        }

    }
}