using ContactManager.Model;
using ContactManager.Service;

namespace ContactManager.Repository
{
    public class ContactRepository : IContactRepository
    {
        private static IList<ContactModel> contacts = new List<ContactModel>();
        private static int lastId = 0;

        public void Add(ContactModel contact)
        {
            contact.ID = ++lastId;
            contacts.Add(contact);
        }

        public IList<ContactModel> GetAll()
        {
            return contacts.ToList();
        }

        public ContactModel GetById(int id)
        {
            return contacts.FirstOrDefault(x => x.ID == id);
        }

        public void Update(ContactModel contact)
        {
            var existingContact = contacts.FirstOrDefault(x => x.ID == contact.ID);
            if (existingContact != null)
            {
                existingContact.Name = contact.Name;
                existingContact.PhoneNumber = contact.PhoneNumber;
                existingContact.Email = contact.Email;
            }
            else
            {
                throw new ArgumentException("Contact not found");
            }
        }

        public void Delete(int id)
        {
            var contactToRemove = contacts.FirstOrDefault(x => x.ID == id);
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
            }
            else
            {
                throw new ArgumentException("Contact not found");
            }
        }
    }
}


