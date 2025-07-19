
using FamilyTracker.Services;
using FamilyTracker.Services.FamilyRegister;

namespace FamilyTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // Initialize services
            var messenger = new ConsoleMessenger();
            var listService = new ListFamilyMembers(messenger);
            var getFamilyMembers = new GetFamilyMembers();

            var persons = getFamilyMembers.Load();

            messenger.Heading("Family Tracker");
            Console.WriteLine("\nHi, welcome to Family Tracker.");

            string userName;
            do
            {
                messenger.Prompt("\nPlease enter your name:");
                userName = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.Clear();
                    messenger.Error("Invalid input. Please enter a valid name.");
                }

            } while (string.IsNullOrWhiteSpace(userName));

            Console.Clear();
            Console.WriteLine($"Hi, {userName}, here is trhe main menu");

            // FamilyRegistration.Start(persons, userName, messenger, listService);
            MenuHandler.AfterAddingMembersMenu(persons, userName, messenger, listService);
        }

    }
}


