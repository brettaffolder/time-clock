using TimeClock.Maui.ViewModels;

namespace TimeClock.Maui.Dialogs;

public partial class EmployeesDialog : ContentPage
{
	public EmployeesDialog(EmployeesViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
	}
}
