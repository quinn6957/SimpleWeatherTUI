using IPGeolocation;
using HttpClient = System.Net.Http.HttpClient;


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

        

    }
}