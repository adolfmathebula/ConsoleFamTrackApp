using FamilyTracker.Models;

namespace FamilyTracker.Services
{
    public static class FamilyRegistration
    {
        public static void Start(List<Person> persons, string userName, ConsoleMessenger messenger, ListFamilyMembers listService)
        {
            FamilyRegister.AskToRegister.Prompt(persons, userName, messenger, listService);
        }
    }
}