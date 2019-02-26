using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.DTO.Order;
using WebStore.Entities.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [ApiController, Route("api/[controller]"), Produces("application/json")]
    public class OrdersController : ControllerBase, IOrderService
    {
        private readonly IOrderService _OrderService;

        public OrdersController(IOrderService OrderService) => _OrderService = OrderService;

        [HttpGet("user/{UserName}")]
        public IEnumerable<OrderDTO> GetUserOrders(string UserName) => _OrderService.GetUserOrders(UserName);

        [HttpGet("{id}"), ActionName("Get")]
        public OrderDTO GetOrderById(int id) => _OrderService.GetOrderById(id);

        [HttpPost("{UserName?}")]
        public OrderDTO CreateOrder([FromBody] CreateOrderModel Order, string UserName) => _OrderService.CreateOrder(Order, UserName);
    }
}