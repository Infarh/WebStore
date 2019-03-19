using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.Entities.DTO;
using WebStore.Entities.DTO.Product;
using WebStore.Entities.Entries;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Services.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(IConfiguration configuration) : base(configuration) => ServiceAddress = "api/products";

        public IEnumerable<Section> GetSections() => Get<List<Section>>($"{ServiceAddress}/sections");

        public Section GetSectionById(int id) => Get<Section>($"{ServiceAddress}/sections/{id}");

        public IEnumerable<Brand> GetBrands() => Get<List<Brand>>($"{ServiceAddress}/brands");

        public Brand GetBrandById(int id) => Get<Brand>($"{ServiceAddress}/brands/{id}");

        public PagedProductDTO GetProducts(ProductFilter Filter) => 
            Post($"{ServiceAddress}", Filter)
            .Content
            .ReadAsAsync<PagedProductDTO>()
            .Result;

        public ProductDTO GetProductById(int id) => Get<ProductDTO>($"{ServiceAddress}/{id}");
    }
}
