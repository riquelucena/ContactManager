using ContactManager.Model;

namespace ContactManager.Interfaces
{
    public interface IAddContactsBusiness
    {
        void Add(ContactModel contact);
    }
}