using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.Entries;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _ProductData;

        public CatalogController(IProductData ProductData) => _ProductData = ProductData;

        public IActionResult Shop(int? SectionId, int? BrandId)
        {
            var products = _ProductData.GetProducts(new ProductFilter { SectionId = SectionId, BrandId = BrandId });

            var model = new CatalogViewModel
            {
                BrandId = BrandId,
                SectionId = SectionId,
                Products = products.Select(product => new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Order = product.Order,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Brand = product.Brand != null ? product.Brand.Name : string.Empty
                }).OrderBy(product => product.Order).ToList()
            };

            return View(model);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _ProductData.GetProductById(id);
            return product is null ? 
                (IActionResult) NotFound() 
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
    }
}