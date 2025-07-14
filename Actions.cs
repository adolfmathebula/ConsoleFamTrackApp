using System;

public class Actions
{
    //show error message
    public void ErrorResponse(String message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    //show success message
    public void SuccessResponse(String message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    //show action message
    public void ActionResponse(String message)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void ShowMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void ShowHeading(String message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"~~~~~{message}~~~~~");
        Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nHere is the list:\n");
            Console.ResetColor();

            for (int i = 0; i < persons.Count; i++)
            {
                string gender = persons[i].Gender.ToLower() == "m" ? "Male" : "Female";

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"  {i + 1}. {persons[i].Name} -- {persons[i].Age} Years -- {gender}");
                Console.ResetColor();
            }
        }
    }
}


          