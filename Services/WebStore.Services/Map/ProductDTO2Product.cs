using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Entities.DTO;
using WebStore.Entities.DTO.Product;
using WebStore.Entities.Entries;

namespace WebStore.Services.Map
{
    public static class ProductDTO2Product
    {
        public static ProductDTO Map(Product product) => new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            Order = product.Order,
            Brand = product.Brand is null
                ? null
                : new BrandDTO
                {
                    Id = product.Brand.Id,
                    Name = product.Brand.Name,
                },
            Section = product.Section is null
                ? null
                : new SectionDTO
                {
                     Id = product.Section.Id,
                     Name = product.Section.Name
                }   
        };

        public static Product Map(ProductDTO product) => new Product
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Order = product.Order,
            ImageUrl = product.ImageUrl,
            BrandId = product.Brand?.Id,
            Brand = product.Brand is null
                ? null
                : new Brand
                {
                    Id = product.Brand.Id,
                    Name = product.Brand.Name
                }
        };
    }
}
