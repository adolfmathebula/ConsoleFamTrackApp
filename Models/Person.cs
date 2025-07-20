namespace FamilyTracker.Models
{
  public class Person(int id, string name, int age, string gender)
  {
    public int Id { get; } = id;
    public string Name { get; } = name;
    public int Age { get; } = age;
    public string Gender { get; } = gender;
  }

}

// NOTES
// public class Person
// {
//     public string Name { get; }
//     public int Age { get; }
//     public string Gender { get; }

//     public Person(string name, int age, string gender)
//     {
//         Name = name;
//         Age = age;
//         Gender = gender;
//     }
// }