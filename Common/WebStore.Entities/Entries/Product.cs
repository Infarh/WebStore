using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Entities.Entries.Base;
using WebStore.Entities.Entries.Base.Interfaces;

namespace WebStore.Entities.Entries
{
    /// <summary>Товар</summary>
    [Table("Products")]
    public class Product : NamedEntry, IOrderedEntry
    {
        public int Order { get; set; }

        /// <summary>Секция товара</summary>
        public int SectionId { get; set; }

        [ForeignKey(nameof(SectionId))]
        public virtual Section Section { get; set; }

        /// <summary>Бренд товара</summary>
        public int? BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }

        /// <summary>Ссылка на картинку</summary>
        public string ImageUrl { get; set; }

        /// <summary>Цена</summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
