using System.Text.Json;
using FamilyTracker.Models;

namespace FamilyTracker.Services
{
    public class GetFamilyMembers
    {
        private readonly string filePath = "./data/familyMembers.json";

        public List<Person> Load()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    var persons = JsonSerializer.Deserialize<List<Person>>(json);
                    return persons ?? new List<Person>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading family members: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("No family data file found. Starting with an empty list.");
            }

            return new List<Person>();
        }
    }
}
