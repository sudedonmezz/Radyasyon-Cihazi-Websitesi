using Services.Contracts;
using Entities.Models;
namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IAuthService _authService;

        private readonly IProductAnalysisService _productAnalysisService;

        private readonly ISupportMessageService _supportMessageService;

        private readonly IContactMessageService _contactMessageService;


        public ServiceManager(IProductService productService, ICategoryService categoryService, IOrderService orderService, IAuthService authService, ISupportMessageService supportMessageService, IProductAnalysisService productAnalysisService, IContactMessageService contactMessageService)
        {
            _productAnalysisService = productAnalysisService;
            _supportMessageService = supportMessageService;
            _authService = authService;
            _orderService = orderService;
            _productService = productService;
            _categoryService = categoryService;
            _contactMessageService = contactMessageService;
        }
        public IProductService ProductService => _productService;
        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;

        public IAuthService AuthService => _authService;

        public ISupportMessageService SupportMessageService => _supportMessageService;

        public IProductAnalysisService ProductAnalysisService => _productAnalysisService;

        public IContactMessageService ContactMessageService => _contactMessageService;
    }
}