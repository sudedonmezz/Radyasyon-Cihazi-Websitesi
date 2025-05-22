using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ZSStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class DashboardController:Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Product");
        }
    }
}