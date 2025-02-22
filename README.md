# My C# Practice Journey: Building a Family Register App

## Introduction
As part of my journey to improve my C# skills, I decided to build a simple yet functional **Family Register Application**. This project helped me understand and apply fundamental programming concepts in C#, including **object-oriented programming (OOP), user input validation, recursion, collections, and console interactions**.

---

## Concepts I Learned

### 1. Object-Oriented Programming (OOP)
One of the primary goals of this project was to implement **classes** and **objects** effectively. I created multiple classes to separate concerns:

- **`Person.cs`**: A class representing a family member with properties for `Name`, `Age`, and `Gender`.
- **`Actions.cs`**: A helper class to handle console messages with different colors for errors and success messages.
- **`FamilyRegister.cs`**: The main logic for registering and displaying family members.

### 2. Working with Constructors
I defined a constructor in `Person.cs` to initialize objects when a new family member is created.

```csharp
public class Person (string name, int age, string gender)
{
  public string Name { get; } = name;
  public int Age { get; } = age;
  public string Gender { get; } = gender;
}
```
This helped me understand **how constructors streamline object creation**.

### 3. Handling User Input & Validation
User input validation is critical to ensure data integrity. I implemented input validation in `FamilyRegister.cs` using loops and conditional checks:

```csharp
while (string.IsNullOrWhiteSpace(memberName))
{
    actions.ErrorResponse("Invalid input. Please enter a valid name.");
    GetName();
}
```

I also used `int.TryParse()` to ensure the user enters a valid age.

### 4. Working with Lists and Collections
The program stores all registered family members in a `List<Person>`, allowing dynamic data management.

```csharp
List<Person> persons = new List<Person>();
```

This list is updated as new members are added, demonstrating the importance of **collections in C#**.

### 5. Recursion for Repeated User Prompts
Instead of using loops, I explored **recursion** in `AskToRegister()` to repeatedly prompt users for input until they provide a valid response:

```csharp
if (register == "y")
{
    RegisterMember(persons, userName, actions);
}
else if (register == "n")
{
    actions.SuccessResponse($"Goodbye {userName}, thanks for visiting.");
}
else
{
    actions.ErrorResponse("Please enter only 'y' or 'n'.");
    AskToRegister(persons, userName, actions);
}
```

### 6. Console UI Enhancements with Colors
To improve the user experience, I used `ConsoleColor` to display messages in different colors:

```csharp
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Invalid input. Please enter a valid name.");
Console.ResetColor();
```

This small enhancement made my console application more interactive and readable.

---

## Final Thoughts
Building this project allowed me to **apply multiple C# concepts in a practical setting**. I gained hands-on experience with **OOP, collections, recursion, and user input validation**, which are essential skills for any C# developer.

This was a great learning experience, and I look forward to refining this project further by adding file storage and data persistence!


