using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.Entities.DTO.Order;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Services.Orders
{
    public class OrdersClient : BaseClient, IOrderService
    {
        public OrdersClient(IConfiguration configuration) : base(configuration) => ServiceAddress = "api/orders";

        public IEnumerable<OrderDTO> GetUserOrders(string UserName) => Get<List<OrderDTO>>($"{ServiceAddress}/user/{UserName}");

        public OrderDTO GetOrderById(int id) => Get<OrderDTO>($"{ServiceAddress}/{id}");

        public OrderDTO CreateOrder(CreateOrderModel Order, string UserName) =>
            Post($"{ServiceAddress}/{UserName}", Order)
                .Content
                .ReadAsAsync<OrderDTO>()
                .Result;
    }
}
