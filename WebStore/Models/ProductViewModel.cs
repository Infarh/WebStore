using System;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Entities.Entries.Base.Interfaces;

namespace WebStore.Models
{
    /// <summary>Модель описания товара</summary>
    public class ProductViewModel : INamedEntry, IOrderedEntry
    {
        /// <summary>Идентификатор товара</summary>
        public int Id { get; set; }
        /// <summary>Название товара</summary>
        public string Name { get; set; }
        /// <summary>Порядковый номер сортировки</summary>
        public int Order { get; set; }
        /// <summary>Ссылка на файл с изображением</summary>
        public string ImageUrl { get; set; }
        /// <summary>Цена</summary>
        public decimal Price { get; set; }
        /// <summary>Бренд</summary>
        public string Brand { get; set; }
    }
}
