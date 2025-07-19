using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using dotenv.net;
using Spectre.Console;

namespace SimpleWeatherTUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UI.UITitle("simple weather tui");

            string[] menuOptions = {
            "get weather based on your ip.",
            "get weather based on a city.",
            "TEST_IPGEOHELPER_GETIP", // for testing purposes
            "TEST_IPGEOHELPER_GETGEOLOCATION", // for testing purposes
            "exit"
        };

            string selectedOption = UI.UISelection(
                "in what way would you like your weather?",
                "[grey]use [arrow up/down] to navigate, [enter] to select[/]",
                menuOptions
            );


            if (selectedOption == "exit")
            {
                UI.UIMessage("okay, closing.");
                System.Environment.Exit(0);
            }
            else if (selectedOption == "get weather based on your ip.")
            {
                try
                {
                    UI.UIMessage("attempting to get weather from your ip address...");
                    NotYetReady();
                }
                catch (Exception ex)
                {
                    UI.UIException(ex);
                }
            }
            else if (selectedOption == "get weather based on a city.")
            {

                var SelectedCity = UI.UITextInput("what city in what country would you like weather for?\n use the two letter code for the country you want or else it won't work, sorry.\n");

                try
                {
                    UI.UIMessage($"attempting to get weather for {SelectedCity}...");
                    NotYetReady();
                }
                catch (Exception ex)
                {
                    UI.UIException(ex);
                }
            }
            else if (selectedOption == "TEST_IPGEOHELPER_GETIP")
            {
                UI.UIMessage("attempting to get your public ip address...");
                try
                {
                    var ip = IPGeoHelper.GetPublicIP().GetAwaiter().GetResult();
                    UI.UIMessage($"your public ip address is: [bold green]{ip}[/]");
                }
                catch (Exception ex)
                {
                    UI.UIException(ex, "failed to get your public ip address");
                }
            }
            else if (selectedOption == "TEST_IPGEOHELPER_GETGEOLOCATION")
            {
                UI.UIMessage("attempting to get your geolocation based on your public ip address...");
                try
                {
                    var ip = IPGeoHelper.GetPublicIP().GetAwaiter().GetResult();
                    var geoLocation = IPGeoHelper.GetGeolocation(ip);
                    UI.UIMessage($"your geolocation is: [bold green]{geoLocation}[/]");
                }
                catch (Exception ex)
                {
                    UI.UIException(ex, "failed to get your geolocation");
                }
            }
            else
            {
                UI.UIMessage("unrecognized option, exiting.");
                System.Environment.Exit(1);
            }
        }

        public static void NotYetReady()
        {
            throw new NotImplementedException();
        }
    }
}