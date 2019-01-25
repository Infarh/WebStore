using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entries;

namespace WebStore.Infrastructure.Interfaces
{
    /// <summary>Сервис продуктов</summary>
    public interface IProductData
    {
        /// <summary>Получить секции</summary>
        /// <returns></returns>
        IEnumerable<Section> GetSections();

        /// <summary>Получить бренды</summary>
        /// <returns></returns>
        IEnumerable<Brand> GetBrands();
    }
}
