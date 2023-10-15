using Adressbook.Mvvm.Models;
using Adressbook.Mvvm.Views;
using Adressbook.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Adressbook.Mvvm.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        private readonly ContactService _contactService;

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();
        public MainViewModel(ContactService contactService)
        {
            _contactService = contactService;
            GetContacts();

            _contactService.ContactsUpdated += GetContacts;
        }

        private void GetContacts()
        {
            Contacts.Clear();

            foreach (var contact in _contactService.GetContactsFromList())
                Contacts.Add(contact);
        }

        [RelayCommand]
        public async Task GoToDetail(ContactModel contact)
        {
            
            var viewModel = new DetailViewModel(contact.Id, new ContactService());
            var detailPage = new DetailPage(viewModel);
            await Shell.Current.Navigation.PushAsync(detailPage);

        }

        [RelayCommand]
        public async Task GoToUpdate()
        {
            await Shell.Current.GoToAsync(nameof(UpdateContactPage));
        }

        [RelayCommand]
        public async Task GoToAdd()
        {
            await Shell.Current.GoToAsync(nameof(AddPage));
        }

        [RelayCommand]
        public async Task GoToShowAll()
        {
            await Shell.Current.GoToAsync(nameof(ShowAllPage));
        }

       // [RelayCommand]
       // public async Task GoToSort()
      //  {
          //  await Shell.Current.GoToAsync(nameof());
      //  }

      //  [RelayCommand]
        //public async Task GoToDelete()
      //  {
          //  await Shell.Current.GoToAsync(nameof());
      //  }

    }
}
  