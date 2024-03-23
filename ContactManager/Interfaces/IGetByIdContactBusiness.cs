using ContactManager.Model;

namespace ContactManager.Interfaces
{
    public interface IGetByIdContactBusiness
    {
        Task<ContactModel> GetByIdAsync(int id);
    }
}