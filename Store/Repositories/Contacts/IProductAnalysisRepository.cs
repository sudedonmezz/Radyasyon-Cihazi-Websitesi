using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductAnalysisRepository : IRepositoryBase<ProductAnalysis>
    {
        
    IEnumerable<ProductAnalysis> GetAll();

    }
}
