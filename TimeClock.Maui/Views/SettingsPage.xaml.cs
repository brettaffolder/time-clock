using TimeClock.Maui.ViewModels;

namespace TimeClock.Maui.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsViewModel ViewModel { get; }

    public SettingsPage(SettingsViewModel viewModel)
	{
		InitializeComponent();

        ViewModel = viewModel;
	}
}
