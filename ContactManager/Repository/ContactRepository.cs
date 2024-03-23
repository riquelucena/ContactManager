using ContactManager.Service;

namespace ContactManager.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _dbContext;

    }
}
