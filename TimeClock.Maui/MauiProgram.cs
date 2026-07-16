using TimeClock.Maui.ViewModels;
using TimeClock.Maui.Views;

namespace TimeClock.Maui;

public static class MauiProgram
{
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

        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<EmployeesViewModel>();
        builder.Services.AddSingleton<LogsViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<EmployeesPage>();
        builder.Services.AddSingleton<LogsPage>();
        builder.Services.AddSingleton<SettingsPage>();

        return builder.Build();
    }
}
