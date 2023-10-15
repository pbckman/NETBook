using Adressbook.Mvvm.Models;
using Adressbook.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbook.Mvvm.ViewModels
{
    public partial class AddViewModel : ObservableObject
    {
        private readonly ContactService _contactService;

        public AddViewModel(ContactService contactService)
        {
            _contactService = contactService;
        }

        [ObservableProperty]
        private string firstName;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string phone;

        [ObservableProperty]
        private string adress;

        [RelayCommand]
        public async Task Save()
        {
            var contact = new ContactModel()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                Adress = Adress,
            };

            _contactService.AddContactsToList(contact);

            await Shell.Current.GoToAsync("..");
        }
    }
}
