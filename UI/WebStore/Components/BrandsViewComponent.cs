using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.ViewModels;
using WebStore.Entities.ViewModels.Products;
using WebStore.Interfaces.Services;
using WebStore.Services.Map;

namespace WebStore.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;

        public BrandsViewComponent(IProductData ProductData) => _ProductData = ProductData;

        public IViewComponentResult Invoke(string BrandId)
        {
            var brand_id = int.TryParse(BrandId, out var id) ? id : (int?) null;
            return View(new BrandCompleteViewModel { Brands = GetBrands(), CurrentBrandId = brand_id });
        }

        private IEnumerable<BrandViewModel> GetBrands() => _ProductData
            .GetBrands()
            .Select(brand => brand.Map())
            .OrderBy(brand => brand.Order)
            .ToList();
    }
}
