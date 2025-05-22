using Microsoft.AspNetCore.Mvc;

namespace ZSStore.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}