using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Text;
using WebStore.Entities.Entries.Base;

namespace WebStore.Entities.Entries
{
    /// <summary>Элемент заказа</summary>
    public class OrderItem : BaseEntry
    {
        /// <summary>Заказ</summary>
        public virtual Order Order { get; set; }

        /// <summary>Заказанный товар</summary>
        public virtual Product Product { get; set; }

        /// <summary>Цена</summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        /// <summary>Количество</summary>
        public int Quantity { get; set; }
    }
}
