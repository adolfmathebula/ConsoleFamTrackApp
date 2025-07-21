# Family Tracker: A C# Console Application

##  Overview


A feature-rich, console-based application for registering and managing family records with persistent JSON storage, built with modern C# and .NET 9. This practice project showcases core programming concepts such as **object-oriented programming, collections, input validation, recursion**, and a user-friendly interface enhanced with colored console outputs


## Technical Highlights

- **Object-Oriented Programming (OOP)** with interfaces and implementations  
- **JSON Serialization/Deserialization** for data persistence  
- **Dependency Injection** pattern for services  
- **Advanced Input Validation** with type checking  
- **List Collections** with LINQ operations  
- **Recursive Menu Navigation**  
- **Spectre.Console Integration** for rich UI  
- **File System Operations** for data storage  
- **Defensive Programming** with null checks  
- **Auto-incrementing ID System**


##  App Features

- **CRUD Operations**: Add, list, and delete family members with auto-incrementing IDs.
- **JSON Data Persistence**: Automatically saves/loads data to `./data/familyMembers.json`.
- **Rich Console UI**: Styled with [Spectre.Console](https://spectreconsole.net/) for tables, colors, and prompts.
- **Input Validation**: Robust checks for names, integer ages, and gender (M/F).
- **Recursive Menus**: Seamless and smooth navigation using recursive method calls.


## Code Structure

| File/Folder             | Purpose                                                             |
|------------------------|---------------------------------------------------------------------|
| `Program.cs`           | Entry point; initializes services and loads saved data.             |
| `Models/`              | Contains `IPerson` interface and `Person` class.                    |
| `Services/`            | Core logic: registration, deletion, listing, and data persistence.  |
| `ConsoleMessenger.cs`  | A helper class for styled console messages using Spectre.Console.   |


## Key Code Highlights

### 1. JSON Data Persistence

```csharp
// SaveFamilyMembers.cs
public void Save(List<IPerson> persons)  
{
    string json = JsonSerializer.Serialize(persons, new JsonSerializerOptions { WriteIndented = true });
    Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
    File.WriteAllText(filePath, json);
}
```

### 2. Deletion Logic

```csharp
// DeleteFamilyMember.cs
var personToDelete = persons.Find(p => p.Id == userInput);  
if (personToDelete != null)  
{
    persons.Remove(personToDelete);
    SaveFamilyMembers.Save(persons); // Auto-save after deletion
}
```

### 3. Spectre.Console UI Styling

```csharp
// ConsoleMessenger.cs
public void Error(string message) => AnsiConsole.Markup($"[red3_1]{message}[/]");  
public void Success(string message) => AnsiConsole.Markup($"[springgreen3_1]{message}[/]");
```


### 4. Usage

- Enter your name to start.
- Choose from the menu:
- `1`: View all members (with ID table).
- `2`: Add new member (name, age, gender).
- `3`: Delete member by ID.
- `4`: Exit (auto-save happens).


---

##  Future Improvements

- **Relationships:** Add family roles (e.g., Parent, Child).
- **Search & Edit:** Enable member search and editing features.


##  How to Run


### Prerequisites

- .NET 9 SDK installed

### 🛠️ Steps

```bash
git clone https://github.com/your-repo/FamilyTracker.git
cd FamilyTracker
dotnet run
```

---

## Screenshot (old)


![preview](https://github.com/adolfmathebula/ConsoleFamTrackApp/blob/main/screenshot/famtrack1.gif?raw=true)


## License

MIT License – free for reuse and modification.
