using Android.App;
using Android.Runtime;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace TimeClock.Maui;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Application]
public class MainApplication(IntPtr handle, JniHandleOwnership ownership) : MauiApplication(handle, ownership)
{
    protected override MauiApp CreateMauiApp()
    {
        return MauiProgram.CreateMauiApp();
    }
}
