using TimeClock.Maui.ViewModels;

namespace TimeClock.Maui.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;

        viewModel.Page = this;
    }
}
