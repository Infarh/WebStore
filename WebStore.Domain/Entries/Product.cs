using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entries.Base;
using WebStore.Domain.Entries.Base.Interfaces;

namespace WebStore.Domain.Entries
{
    /// <summary>Товар</summary>
    public class Product : NamedEntry, IOrderedEntry
    {
        public int Order { get; set; }

        /// <summary>Секция товара</summary>
        public int SectionId { get; set; }

        /// <summary>Бренд товара</summary>
        public int? BrandId { get; set; }

        /// <summary>Ссылка на картинку</summary>
        public string ImageUrl { get; set; }

        /// <summary>Цена</summary>
        public decimal Price { get; set; }
    }
}
