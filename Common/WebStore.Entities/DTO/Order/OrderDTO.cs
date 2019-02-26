using System;
using System.Collections.Generic;
using WebStore.Entities.Entries.Base;

namespace WebStore.Entities.DTO.Order
{
    /// <summary>Модель передачи данных объекта заказа</summary>
    public class OrderDTO : NamedEntry
    {
        /// <summary>Телефон</summary>
        public string Phone { get; set; }

        /// <summary>Адрес</summary>
        public string Address { get; set; }

        /// <summary>Дата</summary>
        public DateTime Date { get; set; }

        /// <summary>Пункты заказа</summary>
        public IEnumerable<OrderItemDTO> OrderItems { get; set; }
    }
}