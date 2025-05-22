using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface ISupportMessageService
    {
        void Create(SupportMessageForCreationDto dto);
        IEnumerable<SupportMessage> GetAll();
         IEnumerable<SupportMessage> GetMessagesByEmail(string email);


    }
}
