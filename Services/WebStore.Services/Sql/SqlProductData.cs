using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter)
        {
            IQueryable<Product> query = _DataContext.Products;
            if (!(Filter is null) && (!(Filter.SectionId is null) || !(Filter.BrandId is null)))
            {
                if (Filter.BrandId != null)
                    query = query.Where(product => product.BrandId == Filter.BrandId);
                if (Filter.SectionId != null)
                    query = query.Where(product => product.SectionId == Filter.SectionId);

            }

            return query.AsEnumerable().Select(ProductDTO2Product.Map);
        }

        public ProductDTO GetProductById(int id) => ProductDTO2Product.Map(_DataContext.Products.Find(id));
    }
}
