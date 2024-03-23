using ContactManager.Model;

namespace ContactManager.Repository
{
    public interface IContactRepository
    {
        Task AddAsync(ContactModel contact);
        Task<IList<ContactModel>> GetAllAsync();
        Task<ContactModel> GetByIdAsync(int id);
        Task UpdateAsync(ContactModel contact);
        Task DeleteAsync(int id);       
    }
}