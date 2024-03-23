using ContactManager.Interfaces;
using ContactManager.Model;
using ContactManager.Repository;

namespace ContactManager.Business
{
    public class GetAllContactsBusiness : IGetAllContactsBusiness
    {
        private readonly IContactRepository _contactRepository;

        public GetAllContactsBusiness(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IList<ContactModel>> GetAllAsync()
        {
            return await _contactRepository.GetAllAsync();
        }
    }
}
