using System.Collections.Generic;
using WebStore.Entities.ViewModels;

namespace WebStore.Entities.DTO.Order
{
    /// <summary>Модель-представления процесса создания заказа</summary>
    public class CreateOrderModel
    {
        /// <summary>Модель-представление заказа</summary>
        public OrderViewModel OrderViewModel { get; set; }

        /// <summary>Заказы</summary>
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
