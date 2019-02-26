using System.Collections.Generic;
using WebStore.Entities.Entries;
using WebStore.Entities.ViewModels;

namespace WebStore.Interfaces.Services
{
    /// <summary>Сервис управления заказами</summary>
    public interface IOrderService
    {
        /// <summary>Получить все заказы указанного пользователя</summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        IEnumerable<Order> GetUserOrders(string UserName);

        /// <summary>Получить заказ по идентификатору</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Order GetOrderById(int id);

        /// <summary>Создать новый заказ</summary>
        /// <param name="Order">Модель-представления заказа</param>
        /// <param name="Cart">Модель-представления карзины</param>
        /// <param name="UserName">Имя пользователя, создавшего заказ</param>
        /// <returns>Созданный заказ</returns>
        Order CreateOrder(OrderViewModel Order, CartViewModel Cart, string UserName);
    }
}
