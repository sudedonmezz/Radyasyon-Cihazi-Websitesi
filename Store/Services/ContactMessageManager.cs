using System.Linq;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;


namespace Services
{
    public class ContactMessageManager : IContactMessageService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ContactMessageManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void Create(ContactMessageForCreationDto dto)
        {
            var entity = _mapper.Map<ContactMessage>(dto);
            _manager.ContactMessage.Create(entity);
            _manager.Save();
        }

        public IEnumerable<ContactMessage> GetAllMessages()
        {
            return _manager.ContactMessage.FindAll(false).OrderByDescending(x => x.SentAt);
        }

       public void Delete(int id)
{
    var message = _manager.ContactMessage.FindByCondition(m => m.Id == id, true); 

    if (message is not null)
    {
        _manager.ContactMessage.Remove(message);
        _manager.Save();
    }
}

    }
}

