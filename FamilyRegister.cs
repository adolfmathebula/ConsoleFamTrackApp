using System;
using System.Collections.Generic;

namespace FamTrack 
{
    public class FamilyRegister
    {
        public static void AskToRegister(List<Person> persons, string userName, Actions actions)
        {
            string register = (Console.ReadLine() ?? string.Empty).Trim().ToLower() ;

            if (register == "y")
            {
                Console.Clear();
                RegisterMember(persons, userName, actions);
            }
            else if (register == "n")
            {
                Console.Clear();
                actions.SuccessResponse($"Goodbye {userName}, thanks for visiting.");
            }
            else
            {
                actions.ErrorResponse("Please enter only 'y' or 'n'.");
                AskToRegister(persons, userName, actions);
            }
        }

        public static void RegisterMember(List<Person> persons, string userName, Actions actions)
        {
            Console.Clear();
            actions.ShowHeading("REGISTER FAMILY MEMBER");

            string memberName;
            void GetName()
            {
                Console.WriteLine("Enter Family member name:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                memberName = Console.ReadLine() ?? string.Empty;;
                Console.ResetColor();
            }

            GetName();
            while (string.IsNullOrWhiteSpace(memberName))
            {
                actions.ErrorResponse("Invalid input. Please enter a valid name.");
                GetName();
            }

            int memberAge;
            int GetAge()
            {
                Console.WriteLine("Enter their age:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string input = Console.ReadLine() ?? string.Empty;
                Console.ResetColor();

                while (!int.TryParse(input, out memberAge))
                {
                    actions.ErrorResponse("Invalid input. Please enter a valid integer for your age.");
                    input = Console.ReadLine() ?? string.Empty;
                }
                return memberAge;
            }

            memberAge = GetAge();

            string memberGender;
            void GetGender()
            {
                Console.WriteLine("Enter a gender (M/F):");
                Console.ForegroundColor = ConsoleColor.Cyan;
                memberGender = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();
                Console.ResetColor();
            }

            GetGender();
            while (memberGender != "M" && memberGender != "F")
            {
                actions.ErrorResponse("Invalid input. Please enter 'M' or 'F'.");
                GetGender();
            }

            var newMember = new Person(memberName, memberAge, memberGender);
            persons.Add(newMember);
            Console.Clear();

            actions.ShowHeading("REGISTER FAMILY MEMBER");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nMember Added!! \nHere is the list:\n");
            Console.ResetColor();

            for (int i = 0; i < persons.Count; i++)
            {
                string gender = persons[i].Gender.ToLower() == "m" ? "Male" : "Female";

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"  {i + 1}. {persons[i].Name} -- {persons[i].Age} Years -- {gender}");
                Console.ResetColor();
            }

            actions.SuccessResponse("\n" + new string('.', 40));

            Console.WriteLine($"Do you want to Add another member? (Y/N)");
            string addAnother = (Console.ReadLine() ?? string.Empty).ToLower();

            if (addAnother == "y")
            {
                RegisterMember(persons, userName, actions);
            }
            else if (addAnother == "n")
            {
                Console.Clear();
                actions.SuccessResponse($"\n\n\nGoodbye {userName}, thanks for visiting.\n\n\n");
            }
        }
    }
}
