# Family Tracker: A C# Console Application

##  Overview

A console-based application to register and manage family members, built with C# (.NET 9). This practice project demonstrates core programming concepts like **OOP, collections, input validation, and recursion** while providing a user-friendly interface with colored console outputs.

---
## Concepts Learned / Practiced

- Object-Oriented Programming (OOP)
- Working with Constructors
- Handling User Input & Validation
- Working with Lists and Collections
- Recursion for Repeated User Prompts
- Console UI Enhancements with Colors

---
##  App Features

- **Add Family Members**: Record names, ages, and genders (M/F)
- **Input Validation**: Ensures valid data (e.g., non-empty names, numeric ages)
- **Interactive Menus**: Recursive prompts for seamless user interaction
- **List Management**: View all registered members in a formatted list
- **Colorful UI**: Uses `ConsoleColor` for intuitive feedback (errors, success messages)

---

## Code Structure

| File              | Purpose                                      |
|-------------------|----------------------------------------------|
| `Program.cs`      | Entry point; handles initial user setup      |
| `Person.cs`       | Defines the Person class (name, age, gender) |
| `FamilyRegister.cs` | Core logic (registration, menus, recursion) |
| `Actions.cs`      | Helper methods for colored console outputs   |

---

##  Key Code Snippets (Some)

###  OOP with Person Class

```csharp
public class Person(string name, int age, string gender)
{
    public string Name { get; } = name;
    public int Age { get; } = age;
    public string Gender { get; } = gender;
}
```

###  Recursive Menu Handling

```csharp
public static void AskToRegister(List<Person> persons, string userName, Actions actions)
{
    string register = Console.ReadLine()?.Trim().ToLower();
    if (register == "y") RegisterMember(persons, userName, actions);
    else if (register == "n") actions.SuccessResponse($"Goodbye {userName}!");
    else { actions.ErrorResponse("Enter 'y' or 'n'."); AskToRegister(persons, userName, actions); }
}
```

###  Input Validation

```csharp
while (!int.TryParse(input, out memberAge))
{
    actions.ErrorResponse("Invalid age. Enter a number.");
    input = Console.ReadLine() ?? string.Empty;
}
```

---

##  How to Run

### ✅Prerequisites

- .NET 9 SDK installed

### 🛠️ Steps

```bash
git clone https://github.com/your-repo/FamilyTracker.git
cd FamilyTracker
dotnet run
```

### 📋 Usage

- Follow on-screen prompts to add/view family members
- Use `Y`/`N` to navigate menus

---

## 📸 Screenshot

![preview](https://github.com/adolfmathebula/ConsoleFamTrackApp/blob/main/screenshot/famtrack1.gif?raw=true)

---

## 🔧 Future Improvements

- **Data Persistence**: Save/load members to/from a JSON file
- **Extended Fields**: Add relationships (e.g., "Parent", "Sibling")

---

## License

MIT License – free for reuse and modification.
