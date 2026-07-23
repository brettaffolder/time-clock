using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using TimeClock.Core.Models;
using TimeClock.Maui.Contracts;

namespace TimeClock.Maui.DataObjects;

public partial class TimeClock(
    IEmployeeService employeeService,
    ITimeEntryService timeEntryService,
    Employee employee,
    List<TimeEntry> timeEntries) : ObservableObject
{
    private readonly IEmployeeService _employee = employeeService;
    private readonly ITimeEntryService _timeEntry = timeEntryService;

    [ObservableProperty]
    public partial Employee Employee { get; set; } = employee;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanClockIn))]
    [NotifyPropertyChangedFor(nameof(CanClockOut))]
    public partial ObservableCollection<TimeEntry> TimeEntries { get; set; } = [.. timeEntries];

    public bool CanClockIn => TimeEntries.Count == 0 || TimeEntries.LastOrDefault() is null || TimeEntries.LastOrDefault()?.OutTimestamp is not null;

    public bool CanClockOut => TimeEntries.Count > 0 && TimeEntries.LastOrDefault()?.OutTimestamp is null;

    [RelayCommand(CanExecute = nameof(CanClockIn))]
    private async Task ClockIn()
    {
        DateTime now = DateTime.UtcNow;

        var timeEntry = new TimeEntry(
            Guid.CreateVersion7().ToString(),
            Employee,
            now,
            null,
            string.Empty);

        _ = await _timeEntry.AddAsync(timeEntry);

        TimeEntries.Add(timeEntry);
    }

    [RelayCommand(CanExecute = nameof(CanClockOut))]
    private async Task ClockOut()
    {
        DateTime now = DateTime.UtcNow;

        TimeEntry timeEntry = TimeEntries.Last();
        TimeEntry edit = timeEntry with { OutTimestamp = now };

        _ = await _timeEntry.EditAsync(edit);

        TimeEntries.Remove(timeEntry);
        TimeEntries.Add(edit);
    }
}
