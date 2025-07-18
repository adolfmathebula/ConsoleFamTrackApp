using System;
using System.Collections.Generic;
using Spectre.Console;

namespace FamTrack
{
    public class FamilyRegister
    {
        //PROMPT USER TO REGISTER Y/N
        public static void AskToRegister(List<Person> persons, string userName, Actions actions)
        {
            string register = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

            if (register == "y")
            {
                Console.Clear();
                RegisterMember(persons, userName, actions);
            }
            else if (register == "n")
            {
                Console.Clear();
                actions.SuccessResponse($"Goodbye {userName}, thanks for visiting.\n\n");
            }
            else
            {
                actions.ErrorResponse("Please enter only 'y' or 'n'.");
                AskToRegister(persons, userName, actions);
            }
        }


        //REGISTER MEMBER FUNCTION
        // Name, Age, Gender
        public static void RegisterMember(List<Person> persons, string userName, Actions actions)
        {
            Console.Clear();
            actions.ShowHeading("RECORD A FAMILY MEMBER");
            Console.WriteLine("");

            //Enter name
            string memberName;
            void GetName()
            {
                actions.ActionPrompt("Enter Family member's name:");
                memberName = Console.ReadLine() ?? string.Empty; ;
                
            }

            GetName();
            while (string.IsNullOrWhiteSpace(memberName))
            {
                actions.ErrorResponse("Invalid input. Please enter a valid name.");
                GetName();
            }

            //Enter age
            int memberAge;
            int GetAge()
            {
                actions.ActionPrompt("Enter their age:");
                string input = Console.ReadLine() ?? string.Empty;

                while (!int.TryParse(input, out memberAge))
                {
                    actions.ErrorResponse("Invalid input. Please enter a valid integer for their age.");
                    input = Console.ReadLine() ?? string.Empty;
                }
                return memberAge;
            }

            memberAge = GetAge();

            //Enter gender (m/f)
            string memberGender;
            void GetGender()
            {
                actions.ActionPrompt("Enter a gender (M/F):");
                memberGender = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();
            }

            GetGender();
            while (memberGender != "M" && memberGender != "F")
            {
                actions.ErrorResponse("Invalid input. Please enter 'M' or 'F'.");
                GetGender();
            }

            //Add member
            persons.Add(new Person(memberName, memberAge, memberGender));
            Console.Clear();

            actions.ShowHeading("RECORD A FAMILY MEMBER");
            actions.SuccessResponse($"\nFamily member {memberName} has been added successfully. \nHere is the list:\n");

             //Add line - begining of list
            actions.SuccessResponse(new string('.', 40) + "\n\n");

            for (int i = 0; i < persons.Count; i++)
            {
                string gender = persons[i].Gender.ToLower() == "m" ? "Male" : "Female";
                string memberLine = ($"  {i + 1}. {persons[i].Name} ({gender}) -- {persons[i].Age} Years");
                actions.ActionPrompt(memberLine);
            }

            //Add line - end of list
            actions.SuccessResponse("\n" + new string('.', 40));

            //Prompt user to continue adding members
            Continue(persons, userName, actions);
            void Continue(List<Person> persons, string userName, Actions actions)
            {
                Console.WriteLine("\n\nWould you like to add another family member? (Y/N)");
                string response = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

                if (response == "y")
                {
                    RegisterMember(persons, userName, actions);
                }
                else if (response == "n")
                {
                    AfterAddingMembersMenu(persons, userName, actions);
                }
                else
                {
                    actions.ErrorResponse("Please enter only 'y' or 'n'.");
                    Continue(persons, userName, actions);
                }
            }
        }


        //After Adding Members menu
        public static void AfterAddingMembersMenu(List<Person> persons, string userName, Actions actions)
        {
            Console.Clear();
            actions.ShowHeading("Family Tracker");

            Console.WriteLine($"\nHi {userName}, you have recorded {persons.Count} family {(persons.Count > 1 ? "members" : "member")}."); 

            MainMenu(persons, userName, actions);
        }
        
        public static void MainMenu(List<Person> persons, string userName, Actions actions)
        {
            actions.SuccessResponse("\nWhat would you like to do next?\n\n");
            Console.WriteLine("1. View all family members");
            Console.WriteLine("2. Add another family member");
            Console.WriteLine("3. Exit\n");

            string choice = (Console.ReadLine() ?? string.Empty).Trim();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    actions.ShowFamilyMembers(persons, actions);
                    MainMenu(persons, userName, actions);
                    break;
                case "2":
                    RegisterMember(persons, userName, actions);
                    break;
                case "3":
                    Console.Clear();
                    actions.SuccessResponse($"\n\nGoodbye {userName}, thanks for visiting.\n\n");
                    break;
                default:
                    actions.ErrorResponse("Invalid choice. Please try again.");
                    MainMenu(persons, userName, actions);
                    break;
            }
        }
    }
    
    
}
