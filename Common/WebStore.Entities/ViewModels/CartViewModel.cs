using System.Collections.Generic;
using System.Linq;

namespace WebStore.Entities.ViewModels
{
    /// <summary>Модель-представление корзины</summary>
    public class CartViewModel
    {
        /// <summary>Словарь с содержимым корзины: ключ-товар; значение-количество</summary>
        public Dictionary<ProductViewModel, int> Items { get; set; }

        /// <summary>Общее количество содержимого корзины</summary>
        public int ItemsCount => Items?.Sum(i => i.Value) ?? 0;
    }

    /// <summary>Модель корзины</summary>
    public class Cart
    {
        /// <summary>Список элементов корзины</summary>
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        /// <summary>Общее количество содержимого корзины</summary>
        public int ItemsCount => Items?.Sum(i => i.Quantity) ?? 0;
    }

    /// <summary>Позиция корзины</summary>
    public class CartItem
    {
        /// <summary>Идентификатор товара позиции корзины</summary>
        public int ProductId { get; set; }
        /// <summary>Количество товара в позиции</summary>
        public int Quantity { get; set; }
    }
}
