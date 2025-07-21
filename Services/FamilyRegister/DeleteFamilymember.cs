using FamilyTracker.Models;

namespace FamilyTracker.Services.FamilyRegister
{
    public class DeleteFamilyMember
    {
        public void Delete(List<IPerson> persons, string userName, ConsoleMessenger messenger, ListFamilyMembers listService)
        {
            var SaveFamilyMembers = new SaveFamilyMembers();
           
            if (persons.Count == 0)
            {
                messenger.Error("No family members to delete.");
                return;
            }

            messenger.Heading("DELETE A FAMILY MEMBER");
            Console.WriteLine("Select a family member to delete by ID:\n");

            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Id}: {person.Name}");
            }
            messenger.Prompt($"01: Return to Main Menu\n");

            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                if (userInput == 01)
                {
                    FamilyRegister.MenuHandler.AfterAddingMembersMenu(persons, userName, messenger, listService);
                }

                var personToDelete = persons.Find(p => p.Id == userInput);
                if (personToDelete != null)
                {
                    persons.Remove(personToDelete);
                    SaveFamilyMembers.Save(persons);
                    Console.Clear();
                    messenger.Success($"\nSuccessfully deleted {personToDelete.Name}.\n\n");
                    Delete(persons, userName, messenger, listService);
                }
                else
                {
                    Console.Clear();
                    messenger.Error("No family member found with that ID\n\n");
                    Delete(persons, userName, messenger, listService);
                }
            }
            else
            {
                Console.Clear();
                 messenger.Error("Invalid input. Please enter a valid ID.\n\n");
                Delete(persons, userName, messenger, listService);
            }
        }
    }
}