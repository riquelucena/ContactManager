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
    }
}


