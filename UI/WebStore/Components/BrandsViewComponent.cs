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

        public IViewComponentResult Invoke(string BrandId) =>
            View(new BrandCompleteViewModel
            {
                Brands = GetBrands(),
                CurrentBrandId = int.TryParse(BrandId, out var id) ? id : (int?) null
            });

        private IEnumerable<BrandViewModel> GetBrands() => _ProductData
            .GetBrands()
            .Select(Brand2BrandViewModel.Map)
            .OrderBy(brand => brand.Order)
            .ToList();
    }
}
