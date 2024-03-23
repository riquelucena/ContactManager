using ContactManager.Model;

namespace ContactManager.Interfaces
{
    public interface IAddContactsBusiness
    {
        Task AddAsync(ContactModel contact);
    }
}