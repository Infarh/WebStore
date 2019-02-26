using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.Entities.DTO.Order;
using WebStore.Entities.Entries;
using WebStore.Entities.Identity;
using WebStore.Entities.ViewModels;
using WebStore.Interfaces.Services;
using WebStore.Services.Map;

namespace WebStore.Services.Sql
{
    /// <summary>Реализация сервиса управления заказами на основе SQL-сервера БД</summary>
    public class SqlOrderService : IOrderService
    {
        private readonly WebStoreContext _Context;
        private readonly UserManager<User> _UserManager;

        public SqlOrderService(WebStoreContext context, UserManager<User> UserManager)
        {
            _Context = context;
            _UserManager = UserManager;
        }

        public IEnumerable<OrderDTO> GetUserOrders(string UserName) => 
            _Context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .Where(o => o.User.UserName == UserName)
                .AsEnumerable()
                .Select(OrderDTO2Order.Map)
                .ToArray();

        public OrderDTO GetOrderById(int id) => _Context.Orders
            .Include(o => o.OrderItems)
            .Where(o => o.Id == id)
            .AsEnumerable()
            .Select(OrderDTO2Order.Map)
            .FirstOrDefault();

        public OrderDTO CreateOrder(CreateOrderModel Order, string UserName)
        {
            var user = _UserManager.FindByNameAsync(UserName).Result;

            using (var transaction = _Context.Database.BeginTransaction())
            {
                var order = new Order
                {
                    Name = Order.OrderViewModel.Name,
                    Address = Order.OrderViewModel.Address,
                    Date = DateTime.Now,
                    Phone = Order.OrderViewModel.Phone,
                    User = user
                };

                _Context.Orders.Add(order);
                foreach (var item in Order.OrderItems)
                {
                    var product = _Context.Products.FirstOrDefault(p => p.Id == item.Id);
                    if(product is null)
                        throw new InvalidOperationException($"Продукт id:{item.Id} отсутвтует в базе");
                    _Context.OrderItems.Add(new OrderItem
                    {
                        Order = order,
                        Product = product,
                        Price = product.Price,
                        Quantity = item.Quantity
                    });
                }

                _Context.SaveChanges();
                transaction.Commit();

                return OrderDTO2Order.Map(order);
            }
        }
    }
}
