using TimeClock.Core;
using TimeClock.Core.Contracts;
using TimeClock.Core.Models;
using TimeClock.Maui.Contracts;

namespace TimeClock.Maui.Services;

public class TimeEntryService(ILiteDBService liteDB) : ITimeEntryService
{
    private readonly ILiteDBService _liteDB = liteDB;

    private static readonly string s_name = "time_entries";

    public async Task<Result<IEnumerable<TimeEntry>>> AllAsync()
    {
        return await _liteDB.AllAsync<TimeEntry>(s_name);
    }

    public async Task<Result<TimeEntry?>> GetAsync(string id)
    {
        return await _liteDB.GetAsync<TimeEntry>(s_name, id);
    }

    public async Task<Result> AddAsync(TimeEntry timeEntry)
    {
        return await _liteDB.AddAsync(s_name, timeEntry);
    }

    public async Task<Result> EditAsync(TimeEntry timeEntry)
    {
        return await _liteDB.EditAsync(s_name, timeEntry);
    }

    public async Task<Result> DeleteAsync(TimeEntry timeEntry)
    {
        return await _liteDB.DeleteAsync(s_name, timeEntry);
    }
}
