using Entities.Models;

namespace Services.Contracts
{
    public interface IProductAnalysisService
    {
        void Create(ProductAnalysis analysis);
        IEnumerable<ProductAnalysis> GetByProductId(int productId);
        IEnumerable<ProductAnalysis> GetByProductIdAndEmail(int productId, string email);
        IEnumerable<ProductAnalysis> GetAll(); // Ekledik

    }
}