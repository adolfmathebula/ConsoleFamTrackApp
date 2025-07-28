using System;
using System.Collections.Generic;
using FamilyTracker.Models;
using Spectre.Console;

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
                Console.WriteLine("No family members registered yet.\n");
                return;
            }

              //create table for list display
            var table = new Table();

            table.AddColumn("[bold]ID[/]");
            table.AddColumn("[bold]Name[/]");
            table.AddColumn("[bold]Gender[/]");
            table.AddColumn("[bold]Age[/]");

           // table.Title = new TableTitle("[green]Family Members List[/]");
             _messenger.Success("\nFamily Members List\n");
            table.Border(TableBorder.Rounded);
            
            for (int i = 0; i < persons.Count; i++)
            {
                var person = persons[i];
                string gender = person.Gender.ToLower() == "m" ? "Male" : "Female";
                string age = Formatter.GetFormattedAge(person.DateOfBirth);

                table.AddRow($"{i}", person.Name, gender, age);
            }

            AnsiConsole.Write(table);
        }
    };

}