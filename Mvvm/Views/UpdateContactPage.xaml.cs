using Adressbook.Mvvm.ViewModels;

namespace Adressbook.Mvvm.Views;

public partial class UpdateContactPage : ContentPage
{
    public UpdateContactPage()
	{
		InitializeComponent();
		BindingContext = new UpdateContactViewModel();
	}

	private void UpdateButton_Clicked(object sender, EventArgs e)
	{
		var viewModel = (UpdateContactViewModel)BindingContext;

		string newFirstName = firstnameEntry.Text;
		string newLastName = lastnameEntry.Text;
		string newEmail = emailEntry.Text;
		string newPhone = phoneEntry.Text;
		string newAdress = adressEntry.Text;

		viewModel.UpdateContact(newFirstName, newLastName, newEmail, newPhone, newAdress);
	}
}