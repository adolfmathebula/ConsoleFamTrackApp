using System;
using System.Collections.Generic;
using FamilyTracker.Models;

namespace FamilyTracker.Services
{

    public class ListFamilyMembers
    {
        private readonly ConsoleMessenger _messenger;

        public ListFamilyMembers(ConsoleMessenger messenger)
        {
            _messenger = messenger;
        }

        public void Show(List<IPerson> persons)
        {
            if (persons.Count == 0)
            {
                Console.WriteLine("No family members registered yet.");
                return;
            }

            _messenger.Success("\nHere is the list:\n");
            _messenger.Success(new string('.', 40) + "\n\n");

            for (int i = 0; i < persons.Count; i++)
            {
                var person = persons[i];
                string gender = person.Gender.ToLower() == "m" ? "Male" : "Female";
                string line = $"  {i + 1}. {person.Name} ({gender}) -- {person.Age} Years";
                _messenger.Prompt(line);
            }

            _messenger.Success("\n" + new string('.', 40) + "\n");
        }
    }
}