using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace ZSStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactMessageService _service;

        public ContactController(IContactMessageService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]


        public IActionResult List()
        {
            var messages = _service.GetAllMessages();
            return View(messages);
        }

       [HttpPost]
public IActionResult Delete(int id)
{
    _service.Delete(id);
    TempData["Message"] = "Mesaj başarıyla silindi.";
    return RedirectToAction("List");
}


    }
}
