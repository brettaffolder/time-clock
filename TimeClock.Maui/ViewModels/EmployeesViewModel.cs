using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using TimeClock.Core;
using TimeClock.Core.Models;
using TimeClock.Maui.Contracts;
using TimeClock.Maui.Dialogs;
using TimeClock.Maui.Extensions;

namespace TimeClock.Maui.ViewModels;

public partial class EmployeesViewModel(IEmployeeService employee) : ObservableObject
{
    private readonly IEmployeeService _employee = employee;

    public Page? Page { get; set; }
    public INavigation? Navigation { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<Employee> Employees { get; set; } = [];

    [ObservableProperty]
    public partial string Id { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string FirstName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string LastName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Notes { get; set; } = string.Empty;

    [RelayCommand]
    private async Task Refresh()
    {
        Employees.Clear();

        Result<IEnumerable<Employee>> result = await _employee.AllAsync();
        if (result.IsError || result.Value is null)
        {
            if (Page is not null)
            {
                await Page.DisplayAlertAsync("Error", result.Error?.Message, "Close");
            }

            return;
        }

        Employees.AddRange(result.Value.OrderBy(e => e.LastName).ThenBy(e => e.FirstName));
    }

    [RelayCommand]
    private async Task Add()
    {
        if (Navigation is not null)
        {
            await Navigation.PushModalAsync(new EmployeesDialog(this));
        }
    }

    [RelayCommand]
    private async Task Back()
    {
        if (Navigation is not null)
        {
            await Navigation.PopModalAsync();
        }
    }

    [RelayCommand]
    private async Task Save()
    {
        var employee = new Employee(
            Id.Trim(),
            FirstName.Trim(),
            LastName.Trim(),
            Notes.Trim());

        Result result = await _employee.AddAsync(employee);
        if (result.IsError)
        {
            if (Page is not null)
            {
                await Page.DisplayAlertAsync("Error", result.Error?.Message, "Close");
            }

            return;
        }

        Employees.Add(employee);

        Sort();

        Id = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Notes = string.Empty;

        if (Navigation is not null)
        {
            await Navigation.PopModalAsync();
        }
    }

    private void Sort()
    {
        List<Employee> employees = [.. Employees];
        Employees.Clear();
        Employees.AddRange(employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName));
    }
}
