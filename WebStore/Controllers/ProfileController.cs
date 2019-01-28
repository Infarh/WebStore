using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IOrderService _OrderService;

        public ProfileController(IOrderService OrderService) => _OrderService = OrderService;

        public IActionResult Index() => View();

        public IActionResult Orders() =>
            View(_OrderService.GetUserOrders(User.Identity.Name).Select(order => new UserOrderViewModel
            {
                Id = order.Id,
                Name = order.Name,
                Address = order.Address,
                Phone = order.Phone,
                TotalSum = order.Orders.Sum(i => i.Price * i.Quantity)
            }));
    }
}