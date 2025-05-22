using Microsoft.AspNetCore.Mvc;

namespace ZSStore.Components
{
    public class ProductFilterMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}