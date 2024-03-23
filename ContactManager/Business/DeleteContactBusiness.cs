using ContactManager.Interfaces;
using ContactManager.Repository;

namespace ContactManager.Business
{
    public class DeleteContactBusiness : IDeleteContactBusiness
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactBusiness(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void Delete(int id)
        {
            _contactRepository.Delete(id);
        }
    }
}
