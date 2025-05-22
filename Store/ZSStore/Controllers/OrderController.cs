using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace ZSStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly Cart _cart;

        public OrderController(IServiceManager manager, Cart cart)
        {
            _cart = cart;
            _manager = manager;
        }
        [Authorize]
        public ViewResult Checkout() => View(new Order());

       [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Checkout([FromForm] Order order)
{
    if (_cart.Lines.Count() == 0)
    {
        ModelState.AddModelError("", "Üzgünüm, sepetiniz boş.");
    }

    
    ModelState.Remove("Email");

    if (ModelState.IsValid)
    {
        order.Email = User.Identity?.Name; 
        order.Lines = _cart.Lines.ToArray();
        order.OrderedAt = DateTime.Now;

        _manager.OrderService.SaveOrder(order);
        _cart.Clear();

        return RedirectToPage("/Complate", new { OrderId = order.OrderId });
    }

    return View(order);
}

        [Authorize]
public IActionResult MyOrders()
{
    var email = User.Identity?.Name;
    var orders = _manager.OrderService.GetOrdersByEmail(email);
    return View(orders);
}

    }
}