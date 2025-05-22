using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductAnalysisRepository : RepositoryBase<ProductAnalysis>, IProductAnalysisRepository
    {
       
        public ProductAnalysisRepository(RepositoryContext context) : base(context)
        {

        }

        public IEnumerable<ProductAnalysis> GetAll()
        {
           return _context.productAnalyses.Include(p => p.Product).ToList();
        }
    }
}