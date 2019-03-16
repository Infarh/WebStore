using System.Collections.Generic;
using System.Linq;
using WebStore.Entities.DTO;
using WebStore.Entities.DTO.Product;
using WebStore.Entities.Entries;
using WebStore.Interfaces.Services;
using WebStore.Services.Data;
using WebStore.Services.Map;

namespace WebStore.Services.InMemory
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Section> GetSections() => TestData.Sections;

        public Section GetSectionById(int id) => GetSections().FirstOrDefault(s => s.Id == id);

        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public Brand GetBrandById(int id) => GetBrands().FirstOrDefault(b => b.Id == id);

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter)
        {
            IEnumerable<Product> products = TestData.Products;
            if (!(Filter is null) && (!(Filter.SectionId is null) || !(Filter.BrandId is null)))
            {
                if (Filter.SectionId != null)
                    products = products.Where(product => product.SectionId == Filter.SectionId);
                if (Filter.BrandId != null)
                    products = products.Where(product => product.SectionId == Filter.BrandId);
            }

            return products.Select(ProductDTO2Product.Map);
        }

        public ProductDTO GetProductById(int id) => GetProducts(null).FirstOrDefault(product => product.Id == id);
    }
}