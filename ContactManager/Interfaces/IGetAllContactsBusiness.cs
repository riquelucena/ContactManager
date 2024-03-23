using ContactManager.Model;

namespace ContactManager.Interfaces
{
    public interface IGetAllContactsBusiness
    {
        IList<ContactModel> GetAll();
    }
}