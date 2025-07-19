using FamilyTracker.Models;
using FamilyTracker.Services;   

namespace FamilyTracker.Services.FamilyRegister
{
    public static class AskToRegister
    {
        public static void Prompt(List<Person> persons, string userName, ConsoleMessenger messenger, ListFamilyMembers listService)
        {
            Console.Clear();
            messenger.Heading("Family Tracker");
            messenger.Prompt($"\nHi {userName}, are you ready to record a family member? (Y/N)");
            messenger.Prompt("Please enter 'Y' for Yes or 'N' for No:");

            string register = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

            if (register == "y")
            {
                Console.Clear();
                RegisterFlow.RegisterMember(persons, userName, messenger, listService);
            }
            else if (register == "n")
            {
                Console.Clear();
                messenger.Success($"Goodbye {userName}, thanks for visiting.\n\n");
            }
            else
            {
                messenger.Error("Please enter only 'y' or 'n'.");
                Prompt(persons, userName, messenger, listService);
            }
        }
    }
}
