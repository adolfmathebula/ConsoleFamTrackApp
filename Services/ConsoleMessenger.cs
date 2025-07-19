using Spectre.Console;

namespace FamilyTracker.Services
{
    public class ConsoleMessenger
    {
        public void Error(string message) =>
            AnsiConsole.Markup($"[red3_1]{message}[/]");

        public void Success(string message) =>
            AnsiConsole.Markup($"[springgreen3_1]{message}[/]");

        public void Action(string message) =>
            AnsiConsole.Markup($"[yellow3_1]{message}[/]");

        public void Prompt(string message) =>
            AnsiConsole.Markup($"[cyan]{message}\n[/]");

        public void Heading(string message) =>
            AnsiConsole.Markup($"[steelblue1_1]~~~~~{message}~~~~~[/]\n");
    }

}