using FamilyTracker.Models; 

namespace FamilyTracker.Services.FamilyRegister
{
    public static class MenuHandler
    {
        public static void AfterAddingMembersMenu(List<IPerson> persons, string userName, ConsoleMessenger messenger, ListFamilyMembers listService)
        {
            Console.Clear();
            messenger.Heading("Family Tracker");
            Console.WriteLine($"\nHi {userName}, There are {persons.Count} family {(persons.Count == 1 ? "member" : "members")} recorded.");
            MainMenu(persons, userName, messenger, listService);
        }

        public static void MainMenu(List<IPerson> persons, string userName, ConsoleMessenger messenger, ListFamilyMembers listService)
        {

            DeleteFamilyMember deleteFamilyMember = new DeleteFamilyMember();

            messenger.Success("\nWhat would you like to do next?\n");
            Console.WriteLine("1. View all family members");
            Console.WriteLine("2. Add a family member");
            Console.WriteLine("3. Delete a family member");
            Console.WriteLine("4. Exit\n");

            string choice = (Console.ReadLine() ?? string.Empty).Trim();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    listService.Show(persons);
                    MainMenu(persons, userName, messenger, listService);
                    break;
                case "2":
                    RegisterFlow.RegisterMember(persons, userName, messenger, listService);
                    break;
                case "3":
                    deleteFamilyMember.Delete(persons, userName, messenger, listService);
                    break;
                case "4":
                    Console.Clear();
                    messenger.Success($"\n\nGoodbye {userName}, thanks for visiting.\n\n");
                    break;
                default:
                    messenger.Error("Invalid choice. Please try again.");
                    MainMenu(persons, userName, messenger, listService);
                    break;
            }
        }
    }
}
