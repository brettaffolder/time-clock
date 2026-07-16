using TimeClock.Maui.ViewModels;

namespace TimeClock.Maui.Views;

public partial class EmployeesPage : ContentPage
{
    public EmployeesViewModel ViewModel { get; }

    public EmployeesPage(EmployeesViewModel viewModel)
	{
		InitializeComponent();

        ViewModel = viewModel;
	}
}
