using ContactManager.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Service
{
    internal class ContactDbContext : DbContext
    {
        public DbSet<ContactModel> Drugs { get; set; }

        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {
        }
    }
}