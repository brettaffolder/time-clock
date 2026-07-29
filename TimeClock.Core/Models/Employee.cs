namespace TimeClock.Core.Models;

public record Employee : Model
{
    public Employee() : base(string.Empty) { }

    public Employee(string id, string firstName, string lastName, string notes) : base(id)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Notes = notes;
    }

    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Notes { get; init; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";
}
