using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.Entities.DTO;
using WebStore.Entities.DTO.Product;
using WebStore.Entities.Entries;
using WebStore.Interfaces.Services;
using WebStore.Services.Map;

namespace WebStore.Services.Sql
{
    /// <summary>Реализация сервиса управления товарами на основе SQL-сервера БД</summary>
    public class SqlProductData : IProductData
    {
        private readonly WebStoreContext _DataContext;

        public SqlProductData(WebStoreContext DataContext) => _DataContext = DataContext;

        public IEnumerable<Section> GetSections() => _DataContext.Sections.AsEnumerable();

        public Section GetSectionById(int id) => _DataContext.Sections.FirstOrDefault(s => s.Id == id);

        public IEnumerable<Brand> GetBrands() => _DataContext.Brands.AsEnumerable();

        public Brand GetBrandById(int id) => _DataContext.Brands.FirstOrDefault(b => b.Id == id);

        public PagedProductDTO GetProducts(ProductFilter Filter)
        {
            IQueryable<Product> query = _DataContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Section)
                .OrderBy(c => c.Order);

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            var total_count = query.Count();

            if (Filter?.PageSize != null)
                query = query
                    .Skip((Filter.Page - 1) * (int) Filter.PageSize)
                    .Take((int) Filter.PageSize);

            return new PagedProductDTO
            {
                Products = query.AsEnumerable().Select(ProductDTO2Product.Map),
                TotalCount = total_count
            };
        }

        public ProductDTO GetProductById(int id) => _DataContext.Products
            .Include(p => p.Brand)
            .Include(p => p.Section)
            .FirstOrDefault(p => p.Id == id)
            .Map();
    }
}
