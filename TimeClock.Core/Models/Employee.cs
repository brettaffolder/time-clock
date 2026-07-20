namespace TimeClock.Core.Models;

public record Employee(
    string Id,
    string FirstName,
    string LastName,
    string Notes) : Model(Id)
{
    public string FullName => $"{FirstName} {LastName}";

    public override string ToString()
    {
        return FullName;
    }
}
