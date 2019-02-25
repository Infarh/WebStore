using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.ViewModels;
using WebStore.Interfaces.Services;

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

        public IActionResult Details() => View(new DetailsViewModel
        {
            Cart = _CartService.TransformCart(),
            Order = new OrderViewModel()
        });

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

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel Order)
        {
            if (!ModelState.IsValid)
                return View(nameof(Details), new DetailsViewModel
                {
                    Cart = _CartService.TransformCart(),
                    Order = Order
                });

            var order = _OrderService.CreateOrder(Order, _CartService.TransformCart(), User.Identity.Name);
            _CartService.RemoveAll();

            return RedirectToAction(nameof(OrderConfirmed), new { order.Id });
        }

        public IActionResult OrderConfirmed(int Id)
        {
            ViewBag.OrderId = Id;
            return View();
        }
    }
}