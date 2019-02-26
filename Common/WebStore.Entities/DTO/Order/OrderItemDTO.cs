using WebStore.Entities.Entries.Base;

namespace WebStore.Entities.DTO.Order
{
    /// <summary>Модель передачи данных объекта элемента заказа</summary>
    public class OrderItemDTO : BaseEntry
    {
        /// <summary>Цена</summary>
        public decimal Price { get; set; }

        /// <summary>Количество</summary>
        public int Quantity { get; set; }
    }
}