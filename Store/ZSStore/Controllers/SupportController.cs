using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace ZSStore.Controllers
{
    public class SupportController : Controller
    {
        private readonly IServiceManager _manager;

        public SupportController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var email = User.Identity?.IsAuthenticated == true ? User.Identity.Name : "";
            return View(new SupportMessageForCreationDto { Email = email });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(SupportMessageForCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                _manager.SupportMessageService.Create(dto);
               ViewBag.Success = true;
        ModelState.Clear(); 
        return View();
            }
            return View(dto);
        }

        [Authorize]
        public IActionResult Thanks()
        {
            return View();
        }

        [Authorize]
public IActionResult MyMessages()
{
    var email = User.Identity.Name; 
            var messages = _manager.SupportMessageService.GetMessagesByEmail(email);
    return View(messages);
}

    }
}
