using System.Net.Http.Json;
using dotenv;
using dotenv.net;
using Spectre.Console;

namespace SimpleWeatherTUI
{

    public static class WeatherService
    {
        private static readonly HttpClient client = new();

        public static async Task<string> GetWeatherDataAsync(double latitude, double longitude)
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
            if (geolocation == null)
            {
                throw new Exception("Could not retrieve geolocation for the IP address.");
            }

            double latitude = geolocation.Item1;
            double longitude = geolocation.Item2;

            UI.UIPlainMessage($"DEBUG: IP: {ip}, Latitude: {latitude}, Longitude: {longitude}");
            return await GetWeatherDataAsync(latitude, longitude);
        }
    }
}

