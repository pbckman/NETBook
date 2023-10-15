using Adressbook.Mvvm.Views;

namespace Adressbook
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
            Routing.RegisterRoute(nameof(EditPage), typeof(EditPage));
            Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
            Routing.RegisterRoute(nameof(UpdateContactPage), typeof(UpdateContactPage));
            Routing.RegisterRoute(nameof(ShowAllPage), typeof(ShowAllPage));
        }
    }
}