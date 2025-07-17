using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Spectre.Console;

namespace SimpleWeatherTUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UIHelper.UITitle("simple weather tui");

            string[] menuOptions = {
            "get weather based on your ip.",
            "get weather based on a city.",
            "TEST_IPGEOHELPER_GETIP", // for testing purposes
            "exit"
        };

            string selectedOption = UIHelper.UISelection(
                "in what way would you like your weather?",
                "[grey]use [arrow up/down] to navigate, [enter] to select[/]",
                menuOptions
            );


            if (selectedOption == "exit")
            {
                UIHelper.UIMessage("okay, closing.");
                System.Environment.Exit(0);
            }
            else if (selectedOption == "get weather based on your ip.")
            {
                try
                {
                    UIHelper.UIMessage("attempting to get weather from your ip address...");
                    NotYetReady();
                }
                catch (Exception ex)
                {
                    UIHelper.UIException(ex);
                }
            }
            else if (selectedOption == "get weather based on a city.")
            {

                var SelectedCity = UIHelper.UITextInput("what city in what country would you like weather for?\n use the two letter code for the country you want or else it won't work, sorry.\n");

                try
                {
                    UIHelper.UIMessage($"attempting to get weather for {SelectedCity}...");
                    NotYetReady();
                }
                catch (Exception ex)
                {
                    UIHelper.UIException(ex);
                }
            }
            else if (selectedOption == "TEST_IPGEOHELPER_GETIP")
            {
                UIHelper.UIMessage("attempting to get your public ip address...");
                try
                {
                    var ip = IPGeoHelper.GetPublicIP().GetAwaiter().GetResult();
                    UIHelper.UIMessage($"your public ip address is: [bold green]{ip}[/]");
                }
                catch (Exception ex)
                {
                    UIHelper.UIException(ex, "failed to get your public ip address");
                }
            }
            else
            {
                UIHelper.UIMessage("unrecognized option, exiting.");
                System.Environment.Exit(1);
            }
        }

        public static void NotYetReady()
        {
            throw new NotImplementedException();
        }
    }
}