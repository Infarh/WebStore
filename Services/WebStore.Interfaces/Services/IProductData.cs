using System.Collections.Generic;
using WebStore.Entities.DTO;
using WebStore.Entities.DTO.Product;
using WebStore.Entities.Entries;

namespace WebStore.Interfaces.Services
{
    /// <summary>Сервис продуктов</summary>
    public interface IProductData
    {
        /// <summary>Получить секции</summary>
        IEnumerable<Section> GetSections();

        /// <summary>Получить секцию по указанному идентфикатору</summary>
        /// <param name="id">Идентификатор секции</param>
        /// <returns>Секция по указанному идентификатору, либо пустая ссылка, если секция с указанным идетификатором не была найдена</returns>
        Section GetSectionById(int id);

        /// <summary>Получить бренды</summary>
        IEnumerable<Brand> GetBrands();

        /// <summary>Получить товар по идентификатору</summary>
        /// <param name="id">Идентификатор товара</param>
        /// <returns>Товар с указанным идентификатором, либо пустая ссылка, если товар с указанным идентификатором не найден</returns>
        Brand GetBrandById(int id);

        /// <summary>Список товаров</summary>
        /// <param name="Filter">Фильтр товаров</param>
        /// <returns>Выборка товаров, удовлетворяющих указанному фильтру разбитая на страницы</returns>
        PagedProductDTO GetProducts(ProductFilter Filter);

        /// <summary>Поиск продукта по идентификатору</summary>
        /// <param name="id">Идентификатор продукта</param>
        ProductDTO GetProductById(int id);
    }
}
