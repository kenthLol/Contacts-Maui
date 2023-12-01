using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Models;

public static class ContactRepository
{
    public static List<Contact> _contacts = new List<Contact>() {
        new Contact() { ContactId = 1, Name="Kenneth Lola",  Email="kenthexample@gmail.com"},
        new Contact() { ContactId = 2, Name="Angelo Bronte", Email="angeloexample@gmail.com"},
        new Contact() { ContactId = 3, Name="Jim Milton",    Email="jimexample@gmail.com"},
        new Contact() { ContactId = 4, Name="Femton Brooke", Email="femtonexample@gmail.com"},
    };

    //public static List<Contact> GetContacts() { return _contacts; }
    public static List<Contact> GetContacts() => _contacts;

    public static Contact GetContactById(int ContactId)
    {
        var contact = _contacts.FirstOrDefault(x => x.ContactId == ContactId);

        if(contact != null)
        {
            // Se retorna una copia del objeto
            return new Contact
            {
                ContactId = ContactId,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
                Address = contact.Address
            };
        }

        return null;
    }

    public static void UpdateContact(int ContactId, Contact contact)
    {
        if (ContactId != contact.ContactId) return;

        //No se usa el GetContactById porque este retorna una copia
        // y se necesita modificar la lista. Es por eso que se hace directo

        var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == ContactId);

        if(contactToUpdate != null)
        {
            contactToUpdate.Name = contact.Name;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.Phone = contact.Phone;
            contactToUpdate.Address = contact.Address;
        }
    }

    public static void AddContact(Contact contact)
    {
        var maxId = _contacts.Max(x => x.ContactId);
        contact.ContactId = maxId + 1;
        _contacts.Add(contact);
    }
}
