using System;
using System.Collections.Generic;
using FamTrack.Models;
using FamTrack.Services;

namespace FamTrack.Services
{
    public class FamilyRegister
    {
        public static void AskToRegister(List<Person> persons, string userName, ConsoleMessenger messenger, ListFamilyMembers listService)
        {
            Console.Clear();
            messenger.Heading("Family Tracker");
            Console.WriteLine($"\nHi {userName}, are you ready to record a family member? (Y/N)");
            messenger.Prompt("Please enter 'Y' for Yes or 'N' for No:");

            string register = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

            if (register == "y")
            {
                Console.Clear();
                RegisterMember(persons, userName, messenger, listService);
            }
            else if (register == "n")
            {
                Console.Clear();
                messenger.Success($"Goodbye {userName}, thanks for visiting.\n\n");
            }
            else
            {
                messenger.Error("Please enter only 'y' or 'n'.");
                AskToRegister(persons, userName, messenger, listService);
            }
        }

        public static void RegisterMember(List<Person> persons, string userName, ConsoleMessenger messenger, ListFamilyMembers listService)
        {
            Console.Clear();
            messenger.Heading("RECORD A FAMILY MEMBER");
            Console.WriteLine("");

            // Get name
            string memberName;
            do
            {
                messenger.Prompt("Enter family member's name:");
                memberName = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(memberName))
                {
                    messenger.Error("Invalid input. Please enter a valid name.\n");
                }

            } while (string.IsNullOrWhiteSpace(memberName));

            // Get age
            int memberAge;
            while (true)
            {
                messenger.Prompt("Enter their age:");
                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out memberAge)) break;

                messenger.Error("Invalid input. Please enter a valid integer for age.\n");
            }

            // Get gender
            string memberGender;
            do
            {
                messenger.Prompt("Enter a gender (M/F):");
                memberGender = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();

                if (memberGender != "M" && memberGender != "F")
                    messenger.Error("Invalid input. Please enter 'M' or 'F'.\n");

            } while (memberGender != "M" && memberGender != "F");

            // Add member
            persons.Add(new Person(memberName, memberAge, memberGender));
            Console.Clear();
            messenger.Heading("RECORD A FAMILY MEMBER");
            messenger.Success($"\nFamily member {memberName} has been added successfully!!\n");

            listService.Show(persons);

            // Ask to continue
            Continue(persons, userName, messenger, listService);
        }

        private static void Continue(List<Person> persons, string userName, ConsoleMessenger messenger, ListFamilyMembers listService)
        {
            Console.WriteLine("\nWould you like to add another family member? (Y/N)");
            string response = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

            if (response == "y")
            {
                RegisterMember(persons, userName, messenger, listService);
            }
            else if (response == "n")
            {
                AfterAddingMembersMenu(persons, userName, messenger, listService);
            }
            else
            {
                 messenger.Error("Please enter only 'y' or 'n'.");
                Continue(persons, userName, messenger, listService);

            }
        }

        public static void AfterAddingMembersMenu(List<Person> persons, string userName, ConsoleMessenger messenger, ListFamilyMembers listService)
        {
            Console.Clear();
            messenger.Heading("Family Tracker");

            Console.WriteLine($"\nHi {userName}, you have recorded {persons.Count} family {(persons.Count == 1 ? "member" : "members")}.");

            MainMenu(persons, userName, messenger, listService);
        }

        public static void MainMenu(List<Person> persons, string userName, ConsoleMessenger messenger, ListFamilyMembers listService)
        {
            messenger.Success("\nWhat would you like to do next?\n");
            Console.WriteLine("1. View all family members");
            Console.WriteLine("2. Add another family member");
            Console.WriteLine("3. Exit\n");

            string choice = (Console.ReadLine() ?? string.Empty).Trim();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    listService.Show(persons);
                    MainMenu(persons, userName, messenger, listService);
                    break;
                case "2":
                    RegisterMember(persons, userName, messenger, listService);
                    break;
                case "3":
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
