using Adressbook.Mvvm.ViewModels;

namespace Adressbook.Mvvm.Views;

public partial class AddPage : ContentPage
{
    public AddPage(AddViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}