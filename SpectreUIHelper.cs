using Spectre.Console;
using System;

namespace SimpleWeatherTUI
{
    public static class SpectreUIHelper
    {
        public static void UITitle(string title)
        {
            AnsiConsole.Write(new Rule($"[hotpink bold]{title}[/]").Centered());
            AnsiConsole.WriteLine(); // Add a blank line for spacing
        }

        public static string UISelection(string title, string moreChoiceText, string[] choices)
        {
            var UIResult = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .PageSize(10) // You can make this configurable or choose a default
                    .MoreChoicesText(moreChoiceText)
                    .AddChoices(choices)); // Corrected line: Pass the choices array directly

            return UIResult;
        }

        public static void UIMessage(string message)
        {
            AnsiConsole.MarkupLine(message);
        }

        // You can add more helper methods here, for example, for text input:
        public static string UITextInput(string prompt, string? defaultValue = null)
        {
            var promptInstance = new TextPrompt<string>(prompt)
                .AllowEmpty(); // Allows an empty string as input

            if (defaultValue != null)
            {
                promptInstance.DefaultValue(defaultValue);
            }

            return AnsiConsole.Prompt(promptInstance);
        }

        // Example of a confirmation prompt
        public static bool UIConfirm(string prompt)
        {
            return AnsiConsole.Confirm(prompt);
        }



        public static void UIException(Exception ex, string title = "Error Occurred")
        {
            // Display a colored title using a rule
            AnsiConsole.Write(new Rule($"[bold red]{title}[/]").LeftJustified().RuleStyle(Style.Parse("red")));
            AnsiConsole.WriteLine(); // Add a blank line for spacing

            // Write the exception details with default Spectre.Console formatting
            AnsiConsole.WriteException(ex);

            AnsiConsole.WriteLine(); // Add a blank line after the exception
        }
    }
}