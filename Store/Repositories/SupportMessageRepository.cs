using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class SupportMessageRepository : ISupportMessageRepository
    {
        private readonly RepositoryContext _context;

        public SupportMessageRepository(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(SupportMessage message) => _context.SupportMessages.Add(message);
        public IEnumerable<SupportMessage> GetAll() => _context.SupportMessages.ToList();
        public void Save() => _context.SaveChanges();
        public IEnumerable<SupportMessage> GetMessagesByEmail(string email)
    {
        return _context.SupportMessages
                       .Where(m => m.Email == email)
                       .OrderByDescending(m => m.Date)
                       .ToList();
    }
    }
}
