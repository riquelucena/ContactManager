using ContactManager.Model;
using ContactManager.Service;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;
        
        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ContactModel contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<ContactModel>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<ContactModel> GetByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task UpdateAsync(ContactModel contact)
        {
            var existContact = await _context.Contacts.FirstOrDefaultAsync(x => x.ID == contact.ID);
            if (existContact != null)
            {
                existContact.Name = contact.Name;
                existContact.PhoneNumber = contact.PhoneNumber;
                existContact.Email = contact.Email;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Contact not found");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var contactRemove = await _context.Contacts.FirstOrDefaultAsync(x => x.ID == id);
            if (contactRemove != null)
            {
                _context.Contacts.Remove(contactRemove);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Contact not found");
            }
        }
    }
}


