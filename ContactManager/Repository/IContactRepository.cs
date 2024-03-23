using ContactManager.Model;

namespace ContactManager.Repository
{
    public interface IContactRepository
    {
        void Add(ContactModel contact);
        IList<ContactModel> GetAll();
        ContactModel GetById(int id);
        void Update(ContactModel contact);
        void Delete(int id);
    }
}