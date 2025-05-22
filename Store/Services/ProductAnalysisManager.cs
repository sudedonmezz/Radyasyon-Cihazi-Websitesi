using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductAnalysisManager : IProductAnalysisService
    {
        private readonly IRepositoryManager _manager;

        public ProductAnalysisManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void Create(ProductAnalysis analysis)
        {
            _manager.ProductAnalysis.Create(analysis);
            _manager.Save();
        }

        public IEnumerable<ProductAnalysis> GetByProductId(int productId)
        {
            return _manager.ProductAnalysis.FindAll(false)
                .Where(p => p.ProductId == productId)
                .OrderBy(p => p.Timestamp);
        }

        public IEnumerable<ProductAnalysis> GetByProductIdAndEmail(int productId, string email)
        {
            return _manager.ProductAnalysis.FindAll(false)
                .Where(p => p.ProductId == productId && p.UserEmail == email)
                .OrderBy(p => p.Timestamp);
        }

        public IEnumerable<ProductAnalysis> GetAll()
{
    return _manager.ProductAnalysis.GetAll(); 
}

    }
}