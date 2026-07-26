using TimeClock.Maui.ViewModels;

namespace TimeClock.Maui.Views;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel _viewModel;

    public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();

        _viewModel = viewModel;
        BindingContext = viewModel;

        viewModel.Page = this;

        IDispatcherTimer clockTimer = Application.Current!.Dispatcher.CreateTimer();
        clockTimer.Interval = TimeSpan.FromSeconds(1);
        clockTimer.Tick += (_, _) => _viewModel.Time = DateTime.Now.ToString("h:mm tt");
        clockTimer.Start();

        IDispatcherTimer refreshTimer = Application.Current!.Dispatcher.CreateTimer();
        refreshTimer.Interval = TimeSpan.FromMinutes(1);
        refreshTimer.Tick += async (_, _) => await _viewModel.RefreshCommand.ExecuteAsync(null);
        refreshTimer.Start();
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _viewModel.RefreshCommand.ExecuteAsync(null);
    }
}
