using Adressbook.Mvvm.Models;
using Adressbook.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Adressbook.Mvvm.ViewModels;

public partial class DetailViewModel : ObservableObject
{
    private Guid _contactId;
    private readonly ContactService _contactService;

    [ObservableProperty]
    private ContactModel contact;
    public DetailViewModel(Guid contactId, ContactService contactService)
    {
        _contactId = contactId;
        _contactService = contactService;

        Contact = _contactService.GetContactFromList(_contactId);
    }
}
