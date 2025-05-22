using Services.Contracts;
using Entities.Models;
using Repositories.Contracts;
namespace Services
{
    public class CategoryManager:ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager=manager;
        }
       public IEnumerable<Category> GetAllCategories(bool trackchanges)
       {
        return _manager.Category.FindAll(trackchanges);
       }
       
    }
}