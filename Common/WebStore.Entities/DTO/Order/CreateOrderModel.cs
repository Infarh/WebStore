using System.Collections.Generic;
using WebStore.Entities.ViewModels;

namespace WebStore.Entities.DTO.Order
{
    public class CreateOrderModel
    {
        public OrderViewModel OrderViewModel { get; set; }

        /// <summary>Заказы</summary>
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
