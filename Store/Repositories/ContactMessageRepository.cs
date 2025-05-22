using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class ContactMessageRepository : RepositoryBase<ContactMessage>,IContactMessageRepository
    {


        public ContactMessageRepository(RepositoryContext context) : base(context)
        {

        }

    

  

    }
}
