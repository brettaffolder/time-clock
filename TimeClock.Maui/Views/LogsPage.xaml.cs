using TimeClock.Maui.ViewModels;

namespace TimeClock.Maui.Views;

public partial class LogsPage : ContentPage
{
    public LogsViewModel ViewModel { get; }

    public LogsPage(LogsViewModel viewModel)
	{
		InitializeComponent();

        ViewModel = viewModel;
	}
}
