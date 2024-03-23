using ContactManager.Interfaces;
using ContactManager.Model;
using ContactManager.Repository;

namespace ContactManager.Business
{
    public class UpdateContactBusiness : IUpdateContactBusiness
    {
        private readonly IContactRepository _contactRepository;
        
        public UpdateContactBusiness(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void Update(ContactModel contact)
        {
            _contactRepository.Update(contact);
        }
    }}
