using Adressbook.Mvvm.ViewModels;

namespace Adressbook.Mvvm.Views;

public partial class EditPage : ContentPage
{
	public EditPage(EditViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}