using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebStore.Entities.Entries;
using WebStore.Entities.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _ProductData;
        private readonly IConfiguration _Configuration;

        public CatalogController(IProductData ProductData, IConfiguration Configuration) => (_ProductData, _Configuration) = (ProductData, Configuration);

        public IActionResult Shop(int? SectionId, int? BrandId, int Page = 1)
        {
            var page_size = int.Parse(_Configuration["PageSize"]);
            var products = _ProductData.GetProducts(new ProductFilter
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Page = Page,
                PageSize = page_size
            });

            var model = new CatalogViewModel
            {
                BrandId = BrandId,
                SectionId = SectionId,
                Products = products.Products
                    .Select(product => new ProductViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Order = product.Order,
                        Price = product.Price,
                        ImageUrl = product.ImageUrl,
                        Brand = product.Brand?.Name ?? string.Empty
                    })
                    .OrderBy(product => product.Order)
                    .ToArray(),
                PageViewModel = new PageViewModel
                {
                    PageSize = page_size,
                    PageNumber = Page,
                    TotalItems = products.TotalCount
                }
            };

            return View(model);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _ProductData.GetProductById(id);
            return product is null ?
                (IActionResult)NotFound()
                : View(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Order = product.Order,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Brand = product.Brand != null ? product.Brand.Name : string.Empty
                });
        }

        public IActionResult GetFiltredItems(int? SectionId, int? BrandId, int Page = 1)
        {
            var products = GetProducts(SectionId, BrandId, Page, out var total_count);
            return PartialView("Partial/_ProductItems", products);
        }

        private IEnumerable<ProductViewModel> GetProducts(int? SectionId, int? BrandId, int Page, out int TotalCount)
        {
            var products = _ProductData.GetProducts(new ProductFilter
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Page = Page,
                PageSize = int.Parse(_Configuration["PageSize"])
            });
            TotalCount = products.TotalCount;
            return products.Products.Select(p => new ProductViewModel
            {
                Id =  p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                Brand = p.Brand?.Name ?? String.Empty
            }).ToArray();
        }
    }
}