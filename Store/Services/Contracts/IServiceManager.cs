namespace Services.Contracts
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IOrderService OrderService { get; }
        IAuthService AuthService { get; }
        ISupportMessageService SupportMessageService { get; }

        IProductAnalysisService ProductAnalysisService { get; }
        
        IContactMessageService ContactMessageService { get; }
    }
}