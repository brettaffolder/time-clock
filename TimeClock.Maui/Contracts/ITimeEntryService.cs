using TimeClock.Core;
using TimeClock.Core.Models;

namespace TimeClock.Maui.Contracts;

public interface ITimeEntryService
{
    Task<Result<IEnumerable<TimeEntry>>> AllAsync();
    Task<Result<TimeEntry?>> GetAsync(string id);
    Task<Result> AddAsync(TimeEntry timeEntry);
    Task<Result> EditAsync(TimeEntry timeEntry);
    Task<Result> DeleteAsync(TimeEntry timeEntry);
}
