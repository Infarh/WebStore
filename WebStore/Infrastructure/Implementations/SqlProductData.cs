using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL;
using WebStore.Entities.Entries;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    public class SqlProductData : IProductData
    {
        private readonly WebStoreContext _DataContext;

        public SqlProductData(WebStoreContext DataContext) => _DataContext = DataContext;

        public IEnumerable<Section> GetSections() => _DataContext.Sections.AsEnumerable();

        public IEnumerable<Brand> GetBrands() => _DataContext.Brands.AsEnumerable();

        public IEnumerable<Product> GetProducts(ProductFilter Filter)
        {
            if (Filter is null || Filter.SectionId is null && Filter.BrandId is null)
                return _DataContext.Products.AsEnumerable();

            var query = _DataContext.Products.AsQueryable();
            if (Filter.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);
            if (Filter.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            return query.AsEnumerable();
        }

        public Product GetProductById(int id) => _DataContext.Products.Find(id);
    }
}
