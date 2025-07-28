namespace FamilyTracker.Models
{
    public interface IPerson
    {
        int Id { get; }
        string Name { get; }
        DateTime DateOfBirth { get; }
        string Gender { get; }
    }
}