using ContactManager.Model;

namespace ContactManager.Interfaces
{
    public interface IGetAllContactsBusiness
    {
        Task<IList<ContactModel>> GetAllAsync();
    }
}