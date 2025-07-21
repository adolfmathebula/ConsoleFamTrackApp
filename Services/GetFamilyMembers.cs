using System.Text.Json;
using FamilyTracker.Models;

namespace FamilyTracker.Services
{
    public class GetFamilyMembers
    {
        private readonly string filePath = "./data/familyMembers.json";

        public List<IPerson> Load()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    var concreteList = JsonSerializer.Deserialize<List<Person>>(json);

                    // cast deserialized List<Person> to List<IPerson>.
                    return concreteList?.Cast<IPerson>().ToList() ?? new List<IPerson>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading family members: {ex.Message}");
                }
            }

            Console.WriteLine("No family data file found. Starting with an empty list.");
            return new List<IPerson>();
        }
    }
}
