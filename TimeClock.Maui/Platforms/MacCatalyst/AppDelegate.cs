using Foundation;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace TimeClock.Maui;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp()
    {
        return MauiProgram.CreateMauiApp();
    }
}
