using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStore.Entities.DTO.Order;
using WebStore.Entities.Entries;

namespace WebStore.Services.Map
{
    public static class OrderDTO2Order
    {
        public static OrderDTO Map(Order order) => new OrderDTO
        {
            Id = order.Id,
            Name = order.Name,
            Address = order.Address,
            Date = order.Date,
            Phone = order.Phone,
            OrderItems = order.OrderItems.Select(item => new OrderItemDTO
            {
                Id = item.Id,
                Price = item.Price,
                Quantity = item.Quantity
            }).ToArray()
        };
    }
}
