using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Entities.Entries;

namespace WebStore.Infrastructure.Interfaces
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
        IEnumerable<Product> GetProducts(ProductFilter Filter);

        /// <summary>Поиск продукта по идентификатору</summary>
        /// <param name="id">Идентификатор продукта</param>
        Product GetProductById(int id);
    }
}
