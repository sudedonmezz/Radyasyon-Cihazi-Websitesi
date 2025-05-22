using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface IContactMessageService
    {
        void Create(ContactMessageForCreationDto dto);
        IEnumerable<ContactMessage> GetAllMessages();

        void Delete(int id);

    }
}
