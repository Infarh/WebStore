using System.Collections.Generic;
using WebStore.Entities.Entries;
using WebStore.Entities.ViewModels;

namespace WebStore.Interfaces.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetUserOrders(string UserName);
        Order GetOrderById(int id);
        Order CreateOrder(OrderViewModel Order, CartViewModel Cart, string UserName);
    }
}
