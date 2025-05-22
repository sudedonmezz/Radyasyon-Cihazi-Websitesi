using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace ZSStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SupportController : Controller
    {
        private readonly ISupportMessageService _service;

        public SupportController(ISupportMessageService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var messages = _service.GetAll();
            return View(messages);
        }
    }
}
