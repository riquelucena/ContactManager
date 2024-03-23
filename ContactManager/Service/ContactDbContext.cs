using ContactManager.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Service
{
    public class ContactDbContext : DbContext
    {
        public DbSet<ContactModel> Contacts { get; set; }

        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {
        }
    }
}
