using Adressbook.Mvvm.Models;
using Newtonsoft.Json;

namespace Adressbook.Services
{
    public class FileService
    {
        // Event som signalerar att kontakterna har uppdaterats
        public event Action ContactsUpdated;

        // Sparar kontakterna till en JSON-fil
        public void SaveContactsToFile(List<ContactModel> contacts)
        {
            string json = JsonConvert.SerializeObject(contacts); // Konvertera lista till JSON-format
            string filePath = @"C:\Skoluppgifter\Lektion-11\contacts.json";
            File.WriteAllText(filePath, json); // Skriv JSON till en fil
        }

        // Laddar kontakter från JSON-fil
        public List<ContactModel> LoadContactsFromFile()
        {
            if (File.Exists("contacts.json")) // Kontrollera om filen existerar
            {
                string json = File.ReadAllText("contacts.json"); // Läs innehållet i filen
                return JsonConvert.DeserializeObject<List<ContactModel>>(json); // Konvertera JSON till lista
            }

            return new List<ContactModel>(); // Om filen inte finns, returnera en tom lista
        }
    }
}
