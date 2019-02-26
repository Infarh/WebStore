using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.Entities.Entries;
using WebStore.Entities.Identity;
using WebStore.Entities.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Sql
{
    public class SqlOrderService : IOrderService
    {
        private readonly WebStoreContext _Context;
        private readonly UserManager<User> _UserManager;

        public SqlOrderService(WebStoreContext context, UserManager<User> UserManager)
        {
            _Context = context;
            _UserManager = UserManager;
        }

        public IEnumerable<Order> GetUserOrders(string UserName) => 
            _Context.Orders
                .Include(o => o.User)
                .Include(o => o.Orders)
                .Where(o => o.User.UserName == UserName)
                .ToArray();

        public Order GetOrderById(int id) => _Context.Orders
            .Include(o => o.Orders)
            .FirstOrDefault(o => o.Id == id);

        public Order CreateOrder(OrderViewModel Order, CartViewModel Cart, string UserName)
        {
            var user = _UserManager.FindByNameAsync(UserName).Result;

            using (var transaction = _Context.Database.BeginTransaction())
            {
                var order = new Order
                {
                    Name = Order.Name,
                    Address = Order.Address,
                    Date = DateTime.Now,
                    Phone = Order.Phone,
                    User = user
                };

                _Context.Orders.Add(order);
                foreach (var item in Cart.Items)
                {
                    var producn_view_model = item.Key;
                    var quantity = item.Value;
                    var product = _Context.Products.Find(producn_view_model.Id);
                    if(product is null)
                        throw new InvalidOperationException($"Продукт id:{producn_view_model.Id}:{producn_view_model.Name} отсутвтует в базе");
                    _Context.OrderItems.Add(new OrderItem
                    {
                        Order = order,
                        Product = product,
                        Price = product.Price,
                        Quantity = quantity
                    });
                }

                _Context.SaveChanges();
                transaction.Commit();

                return order;
            }
        }
    }
}
