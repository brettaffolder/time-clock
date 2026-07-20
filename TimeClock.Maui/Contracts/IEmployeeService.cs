using TimeClock.Core;
using TimeClock.Core.Models;

namespace TimeClock.Maui.Contracts;

public interface IEmployeeService
{
    Task<Result<IEnumerable<Employee>>> AllAsync();
    Task<Result<Employee?>> GetAsync(string id);
    Task<Result> AddAsync(Employee employee);
    Task<Result> EditAsync(Employee employee);
    Task<Result> DeleteAsync(Employee employee);
}
