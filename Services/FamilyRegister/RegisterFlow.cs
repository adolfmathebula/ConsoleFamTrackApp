using FamilyTracker.Models;
using FamilyTracker.Services;   

namespace FamilyTracker.Services.FamilyRegister
{
    public static class RegisterFlow
    {
        public static void RegisterMember(List<Person> persons, string userName, ConsoleMessenger messenger, ListFamilyMembers listService)
        {
            var addFamilyMember = new SaveFamilyMembers();

            Console.Clear();
            messenger.Heading("RECORD A FAMILY MEMBER");

            // get name
            string memberName;
            do
            {
                messenger.Prompt("Enter family member's name:");
                memberName = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(memberName))
                    messenger.Error("Invalid input. Please enter a valid name.\n");
            } while (string.IsNullOrWhiteSpace(memberName));

            // get age
            int memberAge;
            while (true)
            {
                messenger.Prompt("Enter their age:");
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out memberAge)) break;
                messenger.Error("Invalid input. Please enter a valid integer for age.\n");
            }

            // get gender
            string memberGender;
            do
            {
                messenger.Prompt("Enter a gender (M/F):");
                memberGender = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();
                if (memberGender != "M" && memberGender != "F")
                    messenger.Error("Invalid input. Please enter 'M' or 'F'.\n");
            } while (memberGender != "M" && memberGender != "F");

           // Get the next ID
            int Id = persons.Count > 0 ? persons[^1].Id + 1 : 0;

            var newFamilyMember = new Person(Id, memberName, memberAge, memberGender);
            persons.Add(newFamilyMember);
            addFamilyMember.Save(persons);

            Console.Clear();
            messenger.Heading("RECORD A FAMILY MEMBER");
            messenger.Success($"\nFamily member {memberName} has been added successfully!\n");

            listService.Show(persons);
            
            AskToContinue(persons, userName, messenger, listService);
        }

        private static void AskToContinue(List<Person> persons, string userName, ConsoleMessenger messenger, ListFamilyMembers listService)
        {
            Console.WriteLine("\nWould you like to add another family member? (Y/N)");
            string response = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

            if (response == "y")
                RegisterMember(persons, userName, messenger, listService);
            else if (response == "n")
                MenuHandler.AfterAddingMembersMenu(persons, userName, messenger, listService);
            else
            {
                messenger.Error("Please enter only 'y' or 'n'.");
                AskToContinue(persons, userName, messenger, listService);
            }
        }
    }
}
