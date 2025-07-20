using System.Text.Json;
using FamilyTracker.Models;

namespace FamilyTracker.Services
{
    public class SaveFamilyMembers
    {
        private readonly string filePath = "./data/familyMembers.json";
        public void Save(List<Person> persons)
        {
            try
            {
                string json = JsonSerializer.Serialize(persons, new JsonSerializerOptions { WriteIndented = true });
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save family members: {ex.Message}");
            }
        }
    }
}
