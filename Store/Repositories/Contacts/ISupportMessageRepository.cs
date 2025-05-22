using Entities.Models;

namespace Repositories.Contracts
{
    public interface ISupportMessageRepository
    {
        void Create(SupportMessage message);
        IEnumerable<SupportMessage> GetAll();
        IEnumerable<SupportMessage> GetMessagesByEmail(string email);
        void Save();
         
    }
}
