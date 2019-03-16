using WebStore.Entities.Entries.Base.Interfaces;

namespace WebStore.Entities.DTO.Product
{
    /// <summary>Объект для передачи данных <see cref="Entries.Product"/> - товара</summary>
    public class ProductDTO : INamedEntry, IOrderedEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        /// <summary>Цена</summary>
        public decimal Price { get; set; }

        /// <summary>Адрес изображения</summary>
        public string ImageUrl { get; set; }

        /// <summary>Бренд</summary>
        public BrandDTO Brand { get; set; }

        public SectionDTO Section { get; set; }
    }
}