using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.DTO.Order;
using WebStore.Entities.ViewModels;
using WebStore.Interfaces.Services;
using WebStore.Services.Map;

namespace WebStore.Controllers
{
    /// <summary>Контроллер управления корзиной</summary>
    [Authorize]
    public class CartController : Controller
    {
        /// <summary>Сервис корзины</summary>
        private readonly ICartService _CartService;
        /// <summary>Сервис заказов</summary>
        private readonly IOrderService _OrderService;

        /// <summary>Новый контроллер корзины</summary>
        /// <param name="CartService">Сервис корзины</param>
        /// <param name="OrderService">Сервис заказов</param>
        public CartController(ICartService CartService, IOrderService OrderService) => (_CartService, _OrderService) = (CartService, OrderService);

        /// <summary>Детали корзины</summary>
        /// <returns>Представление деталей корзины</returns>
        public IActionResult Details() => View(new DetailsViewModel { Cart = _CartService.TransformCart(), Order = new OrderViewModel() });

        /// <summary>Частичное представление корзины</summary>
        public IActionResult GetCartView() => ViewComponent("Cart");

        /// <summary>Добавление позиции в корзину</summary>
        /// <param name="id">Идентификатор товара, добавляемого в корзину</param>
        /// <returns>Информация о состоянии корзины в JSON-формате</returns>
        public IActionResult AddToCart(int id)
        {
            _CartService.AddToCart(id);
            return Json(new { id, message = "Товар добавлен в корзину" });
        }

        /// <summary>Уменьшение количества товаров указанного идентификатора в корзине</summary>
        /// <param name="id">Идентификатор товара, количество которого в корзине надо уменьшить</param>
        /// <returns>Перенаправление на метод <see cref="Details"/></returns>
        public IActionResult DecrementFromCart(int id)
        {
            _CartService.DecrementFromCart(id);
            return Json(new { id, message = "Количество товара уменьшено на 1" });
        }

        /// <summary>Удаление из корзины товара с указанным идентификатором</summary>
        /// <param name="id">Идентификатор товара, который требуется удалить из корзины</param>
        /// <returns>Перенаправление на метод <see cref="Details"/></returns>
        public IActionResult RemoveFromCart(int id)
        {
            _CartService.RemoveFromCart(id);
            return Json(new { id, message = "Товар удалён из корзины" });
        }

        /// <summary>Удаление всех позиций из корзины</summary>
        /// <returns>Перенаправление на метод <see cref="Details"/></returns>
        public IActionResult RemoveAll()
        {
            _CartService.RemoveAll();
            return RedirectToAction("Details");
        }

        /// <summary>Оформление заказа по всем позициям корзины</summary>
        /// <param name="Order">Модель-представление заказа</param>
        /// <returns>Представление оформления заказа в случае проблем с моделью, либо перенаправление на метод <see cref="OrderConfirmed"/> в случае успеха</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel Order)
        {
            if (!ModelState.IsValid)
                return View(nameof(Details), new DetailsViewModel
                {
                    Cart = _CartService.TransformCart(),
                    Order = Order
                });

            var create_order_model = new CreateOrderModel
            {
                OrderViewModel = Order,
                OrderItems = _CartService.TransformCart().Items.Select(item => new OrderItemDTO
                {
                    Id = item.Key.Id,
                    Price = item.Key.Price,
                    Quantity = item.Value
                }).ToList()
            };

            var order = _OrderService.CreateOrder(create_order_model, User.Identity.Name);
            _CartService.RemoveAll();

            return RedirectToAction(nameof(OrderConfirmed), new { order.Id });
        }

        /// <summary>Подтверждение заказа</summary>
        /// <param name="Id">Идентификатор заказа</param>
        /// <returns>Представление подтверждения заказа</returns>
        public IActionResult OrderConfirmed(int Id)
        {
            ViewBag.OrderId = Id;
            return View();
        }
    }
}