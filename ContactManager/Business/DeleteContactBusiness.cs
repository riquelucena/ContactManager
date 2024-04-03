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

        public async Task DeleteAsync(int id)
        {
           await _contactRepository.DeleteAsync(id);
        }
    }
}
