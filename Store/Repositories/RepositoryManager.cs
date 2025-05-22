using Repositories.Contracts;
namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;

        private readonly IProductAnalysisRepository _productAnalysis;
        
        private readonly ISupportMessageRepository _supportMessageRepository;

        private readonly IContactMessageRepository _contactMessageRepository;

        public RepositoryManager(IProductRepository productRepository, RepositoryContext context, ICategoryRepository categoryRepository, IOrderRepository orderRepository, ISupportMessageRepository supportMessageRepository, IProductAnalysisRepository productAnalysis,IContactMessageRepository contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
            _productAnalysis = productAnalysis;
            _supportMessageRepository = supportMessageRepository;
            _orderRepository = orderRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _context = context;
        }
        public IProductRepository Product=> _productRepository;
        public ICategoryRepository Category=> _categoryRepository;

        public IOrderRepository Order => _orderRepository;

        

        public ISupportMessageRepository SupportMessageRepository => _supportMessageRepository;

        public IProductAnalysisRepository ProductAnalysis => _productAnalysis;

        public IContactMessageRepository ContactMessage => _contactMessageRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}