using System;
using System.Collections.Generic;
using WebStore.Entities.Entries.Base;
using WebStore.Entities.Identity;

namespace WebStore.Entities.Entries
{
    /// <summary>Заказ</summary>
    public class Order : NamedEntry
    {
        /// <summary>Пользователь, совершивший заказ</summary>
        public virtual User User { get; set; }

        /// <summary>Контактный телефон</summary>
        public string Phone { get; set; }

        /// <summary>Адрес доставки</summary>
        public string Address { get; set; }

        /// <summary>Дата заказа</summary>
        public DateTime Date { get; set; }

        /// <summary>Элементы заказа</summary>
        public virtual ICollection<OrderItem> Orders { get; set; } = new HashSet<OrderItem>();
    }
}