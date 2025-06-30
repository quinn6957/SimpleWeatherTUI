using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Spectre.Console;

namespace SimpleWeatherTUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SpectreUIHelper.UITitle("simple weather tui");

            string[] menuOptions = {
            "get weather based on your ip.",
            "get weather based on a city.",
            "exit"
        };

            string selectedOption = SpectreUIHelper.UISelection(
                "in what way would you like your weather?",
                "[grey]use [arrow up/down] to navigate, [enter] to select[/]",
                menuOptions
            );


            if (selectedOption == "exit")
            {
                SpectreUIHelper.UIMessage("okay, closing.");
                System.Environment.Exit(0);
            }
            else if (selectedOption == "get weather based on your ip.")
            {
                try
                {
                    SpectreUIHelper.UIMessage("attempting to get weather from your ip address...");
                    NotYetReady();
                }
                catch (Exception ex)
                {
                    SpectreUIHelper.UIException(ex);
                }
            }
            else if (selectedOption == "get weather based on a city.")
            {

                var SelectedCity = SpectreUIHelper.UITextInput("what city in what country would you like weather for?\n use the two letter code for the country you want or else it won't work, sorry.\n");

                try
                {
                    SpectreUIHelper.UIMessage($"attempting to get weather for {SelectedCity}...");
                    NotYetReady();
                }
                catch (Exception ex)
                {
                    SpectreUIHelper.UIException(ex);
                }
            }
        }

        public static void NotYetReady()
        {
            throw new NotImplementedException();
        }
    }
}