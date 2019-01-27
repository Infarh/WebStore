using System.Collections.Generic;
using System.Linq;
using WebStore.Data;
using WebStore.Entities.Entries;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Section> GetSections() => TestData.Sections;

        public IEnumerable<Brand> GetBrands() => TestData.Brands;
        public IEnumerable<Product> GetProducts(ProductFilter Filter)
        {
            IEnumerable<Product> products = TestData.Products;
            if (Filter is null || Filter.SectionId is null && Filter.BrandId is null)
                return products;

            if (Filter.SectionId != null)
                products = products.Where(product => product.SectionId == Filter.SectionId);
            if (Filter.BrandId != null)
                products = products.Where(product => product.SectionId == Filter.BrandId);
            return products;
        }

        public Product GetProductById(int id) => GetProducts(null).FirstOrDefault(product => product.Id == id);
    }
}