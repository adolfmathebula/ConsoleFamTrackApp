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

        Console.WriteLine("Hi, welcome to the family register.");
        string userName;

        do
        {
            Console.Write("Please register/enter your name: ");
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
        Console.WriteLine($"Hi, {userName}, ready to register a family member? (Y/N)");
        FamilyRegister.AskToRegister(persons, userName, actions);


    }

 }

   
      
      }





