using dotenv;
using dotenv.net;

namespace SimpleWeatherTUI
{

    public static class WeatherService
    {
        public static async Task<string> GetWeatherDataAsync(string latitude, string longitude)
        {
            DotEnv.Load();
            var envVars = DotEnv.Read();

            var apiKey = envVars["OPENWEATHER_APIKEY"];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception("OPENWEATHER_APIKEY environment variable is not set.");
            }
            using var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}");
            return response;
        }
        public static async Task<string> GetWeatherByIPAsync()
        {
            var ip = await IPGeoHelper.GetPublicIP();
            var geolocation = IPGeoHelper.GetGeolocation(ip);
            var coordinates = geolocation.Split(',');
            if (coordinates.Length != 2)
            {
                throw new Exception("Invalid geolocation data.");
            }
            var latitude = coordinates[0];
            var longitude = coordinates[1];
            return await GetWeatherDataAsync(latitude, longitude);
        }
    }
}

