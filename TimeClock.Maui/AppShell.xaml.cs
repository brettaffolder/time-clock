using TimeClock.Core.Contracts;
using TimeClock.Maui.Views;

namespace TimeClock.Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("home", typeof(HomePage));
        Routing.RegisterRoute("employees", typeof(EmployeesPage));
        Routing.RegisterRoute("logs", typeof(LogsPage));
        Routing.RegisterRoute("settings", typeof(SettingsPage));

        ILiteDBService liteDB = MauiProgram.GetService<ILiteDBService>();
        string folder = Path.Combine(FileSystem.AppDataDirectory, "data");
        _ = Directory.CreateDirectory(folder);
        liteDB.Initialize(folder);
    }
}
