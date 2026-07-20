using TimeClock.Maui.ViewModels;

namespace TimeClock.Maui.Views;

public partial class EmployeesPage : ContentPage
{
    private readonly EmployeesViewModel _viewModel;

    public EmployeesPage(EmployeesViewModel viewModel)
	{
		InitializeComponent();

        _viewModel = viewModel;
        BindingContext = viewModel;

        viewModel.Navigation = Navigation;
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _viewModel.RefreshCommand.ExecuteAsync(null);
    }
}
