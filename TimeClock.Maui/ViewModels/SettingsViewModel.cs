using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TimeClock.Maui.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    public Page? Page { get; set; }

    [RelayCommand]
    private async Task ResetData()
    {
        try
        {
            string folder = Path.Combine(FileSystem.AppDataDirectory, "data");
            _ = Directory.CreateDirectory(folder);

            string employees = Path.Combine(folder, "employees.db");
            string timeEntries = Path.Combine(folder, "time_entries.db");

            File.Delete(employees);
            File.Delete(timeEntries);

            if (Page is not null)
            {
                await Page.DisplayAlertAsync("Success", "Data reset", "Close");
            }
        }
        catch (Exception ex)
        {
            if (Page is not null)
            {
                await Page.DisplayAlertAsync("Error", ex.Message, "Close");
            }
        }
    }
}
