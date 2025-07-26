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

        public static string GetGeolocation(string ip)
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
            var city = json.RootElement.GetProperty("city").GetString();
            var country = json.RootElement.GetProperty("country_code2").GetString();
            return $"{city},{country}";
        }

    }
}