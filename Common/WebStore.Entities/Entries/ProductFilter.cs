using System.Collections.Generic;

namespace WebStore.Entities.Entries
{
    /// <summary>Фильтр товаров</summary>
    public class ProductFilter
    {
        /// <summary>Секция товара</summary>
        public int? SectionId { get; set; }

        /// <summary>Бренд товара</summary>
        public int? BrandId { get; set; }

        /// <summary>Идентификаторы</summary>
        public IEnumerable<int> Ids { get; set; }
    }
}