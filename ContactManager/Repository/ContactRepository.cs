using ContactManager.Model;
using ContactManager.Service;

namespace ContactManager.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;
        
        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }
        public void Add(ContactModel contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public IList<ContactModel> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public ContactModel GetById(int id)
        {
            return _context.Contacts.FirstOrDefault(x => x.ID == id);
        }

        public void Update(ContactModel contact)
        {
            var existContact = _context.Contacts.FirstOrDefault(x => x.ID == contact.ID);
            if (existContact != null)
            {
                existContact.Name = contact.Name;
                existContact.PhoneNumber = contact.PhoneNumber;
                existContact.Email = contact.Email;
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Contact not found");
            }
        }

        public void Delete(int id)
        {
            var contactRemove = _context.Contacts.FirstOrDefault(x => x.ID == id);
            if (contactRemove != null)
            {
                _context.Contacts.Remove(contactRemove);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Contact not found");
            }
        }
    }
}


