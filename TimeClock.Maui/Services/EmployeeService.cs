using TimeClock.Core;
using TimeClock.Core.Contracts;
using TimeClock.Core.Models;
using TimeClock.Maui.Contracts;

namespace TimeClock.Maui.Services;

public class EmployeeService(ILiteDBService liteDB) : IEmployeeService
{
    private readonly ILiteDBService _liteDB = liteDB;

    private static readonly string s_name = "employees";

    public async Task<Result<IEnumerable<Employee>>> AllAsync()
    {
        return await _liteDB.AllAsync<Employee>(s_name);
    }

    public async Task<Result<Employee?>> GetAsync(string id)
    {
        return await _liteDB.GetAsync<Employee>(s_name, id);
    }

    public async Task<Result> AddAsync(Employee employee)
    {
        return await _liteDB.AddAsync(s_name, employee);
    }

    public async Task<Result> EditAsync(Employee employee)
    {
        return await _liteDB.EditAsync(s_name, employee);
    }

    public async Task<Result> DeleteAsync(Employee employee)
    {
        return await _liteDB.DeleteAsync(s_name, employee);
    }
}
