using Adressbook.Mvvm.ViewModels;

namespace Adressbook
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }


    }
}