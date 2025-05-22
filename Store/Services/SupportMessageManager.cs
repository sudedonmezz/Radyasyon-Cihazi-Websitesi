using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class SupportMessageManager : ISupportMessageService
    {
        private readonly ISupportMessageRepository _repo;
         private readonly IRepositoryManager _manager;

    
        private readonly IMapper _mapper;

        public SupportMessageManager(ISupportMessageRepository repo, IMapper mapper,IRepositoryManager manager)
        {
             _manager = manager;
            _repo = repo;
            _mapper = mapper;
        }

        public void Create(SupportMessageForCreationDto dto)
        {
            var entity = _mapper.Map<SupportMessage>(dto);
            _repo.Create(entity);
            _repo.Save();
        }

        public IEnumerable<SupportMessage> GetAll() => _repo.GetAll();

       public IEnumerable<SupportMessage> GetMessagesByEmail(string email)
    {
            return _manager.SupportMessageRepository.GetMessagesByEmail(email);
    }

    }
}
