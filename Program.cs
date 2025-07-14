using System;
using System.Linq;
using System.Collections.Generic;

namespace FamTrack {
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Actions actions = new Actions();
            List<Person> persons = new List<Person>();
            
            actions.ShowHeading("Family Tracker");
            Console.WriteLine("\nHi, welcome to Family Tracker.");
            string userName;

            do
            {
                Console.Write("Please enter your name:\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                userName = Console.ReadLine() ?? string.Empty;;
                Console.ResetColor();
                
                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.Clear();
                    actions.ErrorResponse("Invalid input. Please enter a valid name.");
                }

            } while (string.IsNullOrWhiteSpace(userName));


            Console.Clear();
            Console.WriteLine($"Hi, {userName}, ready to record a family member? (Y/N)");

            FamilyRegister.AskToRegister(persons, userName, actions);
        }
    }   
}





