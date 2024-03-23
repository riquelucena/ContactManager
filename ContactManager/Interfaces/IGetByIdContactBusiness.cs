using ContactManager.Model;

namespace ContactManager.Interfaces
{
    public interface IGetByIdContactBusiness
    {
        ContactModel GetById(int id);
    }
}