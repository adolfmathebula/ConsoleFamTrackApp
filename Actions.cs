using System;

public class Actions
{
     //show error message message
    public  void ErrorResponse(String message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor(); 
    }

     //show error message message
    public  void SuccessResponse(String message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor(); 
    }

     public void ShowMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public  void ShowHeading(String message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"~~~~~~~{message}~~~~~~~");
        Console.ResetColor(); 
    }
}
