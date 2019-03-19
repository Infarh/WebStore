using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Entities.DTO.Product
{
    public class PagedProductDTO
    {
        /// <summary>Выборка продуктов для текущей страницы</summary>
        public IEnumerable<ProductDTO> Products { get; set; }

        /// <summary>Общее количесво в запросе</summary>
        public int TotalCount { get; set; }
    }
}
