using Adressbook.Mvvm.Models;
using Adressbook.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Adressbook.Mvvm.ViewModels
{
    public partial class UpdateContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<ContactModel> _contacts;
        private ContactModel _selectedContact;
        private FileService _fileService;

        public List<ContactModel> Contacts
        {
            get { return _contacts; }
            set 
            { 
                _contacts = value; 
                NotifyPropertyChanged(nameof(Contacts));
            }
        }

        public void LoadContacts()
        {
            Contacts = _fileService.LoadContactsFromFile();
        }

        public UpdateContactViewModel()
        {
            _fileService = new FileService();
        }
        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                NotifyPropertyChanged(nameof(SelectedContact));
            }
        }

        public void UpdateContact(string newFirstName, string newLastName, string newEmail, string newPhone, string newAdress)
        {
            if (SelectedContact != null)
            {
                SelectedContact.FirstName = newFirstName;
                SelectedContact.LastName = newLastName;
                SelectedContact.Email = newEmail;
                SelectedContact.Phone = newPhone;
                SelectedContact.Adress = newAdress;

                SaveContactsToJson(); // Spara ändringarna efter uppdatering
            }

            NotifyPropertyChanged(nameof(SelectedContact));
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void SaveContactsToJson()
        {
            // Hämta befintliga kontakter från JSON-fil
            var jsonString = File.ReadAllText("contacts.json");
            var contacts = JsonSerializer.Deserialize<List<ContactModel>>(jsonString);

            // Hitta och ersätt den befintliga kontakten
            var existingContact = contacts.FirstOrDefault(k => k.Email == SelectedContact.Email);
            if (existingContact != null)
            {
                existingContact.FirstName = SelectedContact.FirstName;
                existingContact.LastName = SelectedContact.LastName;
                existingContact.Email = SelectedContact.Email;
                existingContact.Phone = SelectedContact.Phone;
                existingContact.Adress = SelectedContact.Adress;
            }

            // Spara tillbaka listan med uppdaterade kontakter till JSON-fil
            var nyJsonString = JsonSerializer.Serialize(contacts);
            File.WriteAllText("contacts.json", nyJsonString);
        }
    }
    
}
