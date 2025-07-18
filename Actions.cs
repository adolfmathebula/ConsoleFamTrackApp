using System;
using Spectre.Console;

public class Actions
{
    //show error message
    public void ErrorResponse(String message)
    {
       AnsiConsole.Markup($"[red3_1]{message}[/]");
    }

    //show success message
    public void SuccessResponse(String message)
    {
        AnsiConsole.Markup($"[springgreen3_1]{message}[/]");
    }
    //show action message
    public void ActionResponse(String message)
    {
      AnsiConsole.Markup($"[yellow3_1]{message}[/]");
    }
    
    //user action prompt
    public void ActionPrompt(String message)
    {
        AnsiConsole.Markup($"[cyan]{message}\n[/]");
    }

    public void ShowHeading(String message)
    {
        AnsiConsole.Markup($"[steelblue1_1]~~~~~{message}~~~~~[/]\n");
    }

    public void ShowFamilyMembers(List<Person> persons, Actions actions)
    {
        if (persons.Count == 0)
        {
            Console.WriteLine("No family members registered yet.");
            return;
        }
        else
        {
            actions.ShowHeading("RECORDED FAMILY MEMBER'S LIST");
            actions.SuccessResponse("\nHere is the list:\n");

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
        }
    }
}


          