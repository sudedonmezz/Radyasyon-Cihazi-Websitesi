using Microsoft.AspNetCore.Mvc;
using Entities.Dtos;
using Services.Contracts;

namespace ZSStore.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactMessageService _service;

        public ContactController(IContactMessageService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ContactMessageForCreationDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ContactMessageForCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                _service.Create(dto);
                ViewBag.Success = true;
                return View(new ContactMessageForCreationDto());
            }

            return View(dto);
        }
    }
}
