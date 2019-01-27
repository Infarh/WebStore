using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _CartService;
        private readonly IOrderService _OrderService;

        public CartController(ICartService CartService, IOrderService OrderService)
        {
            _CartService = CartService;
            _OrderService = OrderService;
        }

        public IActionResult Details() => View(new DetailsViewModel { Cart = _CartService.TransformCart(), Order = new OrderViewModel() });

        public IActionResult AddToCart(int id, string ReturnUrl)
        {
            _CartService.AddToCart(id);
            return Redirect(ReturnUrl);
        }

        public IActionResult DecrementFromCart(int id)
        {
            _CartService.DecrementFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _CartService.RemoveFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveAll()
        {
            _CartService.RemoveAll();
            return RedirectToAction("Details");
        }
    }
}