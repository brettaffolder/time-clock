namespace TimeClock.Core.Models;

public record TimeEntry(
    string Id,
    Employee? Employee,
    DateTime? InTimestamp,
    DateTime? OutTimestamp,
    string Notes)
{
    public override string ToString()
    {
        return Id;
    }
}
