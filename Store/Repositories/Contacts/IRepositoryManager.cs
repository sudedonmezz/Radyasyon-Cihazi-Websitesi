namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product{get;}
        ICategoryRepository Category{get;}
        IOrderRepository Order{get;}
        ISupportMessageRepository SupportMessageRepository { get; }

        IProductAnalysisRepository ProductAnalysis { get; }

        IContactMessageRepository ContactMessage { get; }


        void Save();
    }
}