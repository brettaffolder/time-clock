using TimeClock.Core.Contracts;
using TimeClock.Core.Services;
using TimeClock.Maui.Contracts;
using TimeClock.Maui.Services;
using TimeClock.Maui.ViewModels;
using TimeClock.Maui.Views;

namespace TimeClock.Maui;

public static class MauiProgram
{
    private static MauiApp? s_app;

    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<ILiteDBService, LiteDBService>();

        builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
        builder.Services.AddSingleton<ITimeEntryService, TimeEntryService>();

        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<EmployeesViewModel>();
        builder.Services.AddSingleton<LogsViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<EmployeesPage>();
        builder.Services.AddSingleton<LogsPage>();
        builder.Services.AddSingleton<SettingsPage>();

        s_app = builder.Build();

        return s_app;
    }

    public static T GetService<T>() where T : class
    {
        return s_app?.Services.GetRequiredService<T>() ?? throw new NotImplementedException();
    }
}
