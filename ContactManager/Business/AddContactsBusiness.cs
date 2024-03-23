using ContactManager.Interfaces;
using ContactManager.Model;
using ContactManager.Repository;

namespace ContactManager.Business
{
    public class AddContactsBusiness : IAddContactsBusiness
    {
        private readonly IContactRepository _contactRepository;

        public AddContactsBusiness(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task AddAsync(ContactModel contact)
        {
            await _contactRepository.AddAsync(contact);
        }

    }
}
