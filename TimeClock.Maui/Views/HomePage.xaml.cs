using TimeClock.Maui.ViewModels;

namespace TimeClock.Maui.Views;

public partial class HomePage : ContentPage
{
    public HomeViewModel ViewModel { get; }

    public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();

        ViewModel = viewModel;
	}
}
