using Assesment6DotNET.Models;

namespace Assesment6DotNET.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int id);
        Task<Contact> AddContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact);
        Task<Contact> DeleteContact(int id);
        Task<Contact> GetLastInsertedContact();
    }
}
