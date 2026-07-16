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
    }
}
