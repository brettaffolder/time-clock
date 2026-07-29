using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using TimeClock.Core;
using TimeClock.Core.Models;
using TimeClock.Maui.Contracts;

namespace TimeClock.Maui.ViewModels;

public partial class HomeViewModel(
    IEmployeeService employee,
    ITimeEntryService timeEntry) : ObservableObject
{
    private readonly IEmployeeService _employee = employee;
    private readonly ITimeEntryService _timeEntry = timeEntry;

    public Page? Page { get; set; }

    [ObservableProperty]
    public partial string Time { get; set; } = DateTime.Now.ToString("h:mm tt");

    [ObservableProperty]
    public partial ObservableCollection<DataObjects.TimeClock> TimeClocks { get; set; } = [];

    [RelayCommand]
    private async Task Refresh()
    {
        TimeClocks.Clear();

        Result<IEnumerable<Employee>> employeesResult = await _employee.AllAsync();
        if (employeesResult.IsError || employeesResult.Value is null)
        {
            if (Page is not null)
            {
                await Page.DisplayAlertAsync("Error", employeesResult.Error?.Message, "Close");
            }

            return;
        }

        Result<IEnumerable<TimeEntry>> timeEntriesResult = await _timeEntry.AllAsync();
        if (timeEntriesResult.IsError || timeEntriesResult.Value is null)
        {
            if (Page is not null)
            {
                await Page.DisplayAlertAsync("Error", timeEntriesResult.Error?.Message, "Close");
            }

            return;
        }

        foreach (Employee employee in employeesResult.Value.OrderBy(e => e.LastName).ThenBy(e => e.FirstName))
        {
            IEnumerable<TimeEntry> timeEntries = timeEntriesResult.Value.Where(t => t.Employee?.Id == employee.Id);

            TimeClocks.Add(new DataObjects.TimeClock(this, _employee, _timeEntry, employee, [.. timeEntries]));
        }
    }
}
