using System.Collections.Generic;
using WebStore.Entities.DTO;
using WebStore.Entities.Entries;

namespace WebStore.Interfaces.Services
{
    /// <summary>Сервис продуктов</summary>
    public interface IProductData
    {
        /// <summary>Получить секции</summary>
        IEnumerable<Section> GetSections();

        /// <summary>Получить бренды</summary>
        IEnumerable<Brand> GetBrands();

        /// <summary>Список товаров</summary>
        /// <param name="Filter">Фильтр товаров</param>
        IEnumerable<ProductDTO> GetProducts(ProductFilter Filter);

        /// <summary>Поиск продукта по идентификатору</summary>
        /// <param name="id">Идентификатор продукта</param>
        ProductDTO GetProductById(int id);
    }
}
