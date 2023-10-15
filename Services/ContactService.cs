using Adressbook.Mvvm.Models;

namespace Adressbook.Services
{
    public class ContactService
    {
        private List<ContactModel> _contacts = new List<ContactModel>(); // Lista som innehåller kontakter
        private FileService _fileService = new FileService();

        public event Action ContactsUpdated;

        public ContactService(FileService fileService)
        {
            _fileService = fileService;
            _contacts = _fileService.LoadContactsFromFile();
        }

       public ContactService()
        {
        }
       
        public void AddContactsToList(ContactModel contact)
        {
            _contacts.Add(contact);   // spara in kontakt i listan
            _fileService.SaveContactsToFile(_contacts); // spara kontakter till fil
            ContactsUpdated?.Invoke(); // spara listan
        }

        public List<ContactModel> GetContactsFromList()
        {
            return _contacts;
        }

        public ContactModel GetContactFromList(Guid contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == contactId);  // Hämta från fil istället för lista
            if (contact != null)
                return contact;

            return null;
        }
    }
}
