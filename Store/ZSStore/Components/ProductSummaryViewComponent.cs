using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace ZSStore.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager; //!

         public ProductSummaryViewComponent(IServiceManager manager)
         {
            _manager=manager;
         }

         public string Invoke()
         {
            return _manager.ProductService.GetAllproducts(false).Count().ToString();
         }
    }
}