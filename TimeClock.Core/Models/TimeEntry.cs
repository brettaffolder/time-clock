namespace TimeClock.Core.Models;

public record TimeEntry(
    string Id,
    Employee? Employee,
    DateTime? InTimestamp,
    DateTime? OutTimestamp,
    string Notes) : Model(Id)
{
    public override string ToString()
    {
        return Id;
    }
}
