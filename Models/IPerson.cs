namespace FamilyTracker.Models
{
    public interface IPerson
    {
        int Id { get; }
        string Name { get; }
        int Age { get; }
        string Gender { get; }
    }
}