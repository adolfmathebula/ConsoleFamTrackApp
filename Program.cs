using System;
using System.Collections.Generic;
using FamilyTracker.Models;
using FamilyTracker.Services;


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
            var persons = new List<Person>();

            // Heading and greeting
            messenger.Heading("Family Tracker");
            Console.WriteLine("\nHi, welcome to Family Tracker.");

            // Prompt for user name
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
            Console.WriteLine($"Hi, {userName}, are you ready to record a family member? (Y/N)");

            // Register family members
            FamilyRegister.AskToRegister(persons, userName, messenger, listService);
        }
    }
}


