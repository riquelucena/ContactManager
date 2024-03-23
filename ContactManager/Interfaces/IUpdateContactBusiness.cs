using ContactManager.Model;

namespace ContactManager.Interfaces
{
    public interface IUpdateContactBusiness
    {
        Task UpdateAsync(ContactModel contact);
    }
}