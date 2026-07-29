using Bogus;

using TimeClock.Core.Models;

namespace TimeClock.Core.Helpers;

public static class FakeEmployeeHelper
{
    public static Faker<Employee> CreateFaker()
    {
        var id = 1;

        return new Faker<Employee>()
            .RuleFor(e => e.Id, f => (id++).ToString())
            .RuleFor(e => e.FirstName, f => f.Name.FirstName())
            .RuleFor(e => e.LastName, f => f.Name.LastName())
            .RuleFor(e => e.Notes, f => f.Lorem.Sentence(5));
    }
}
