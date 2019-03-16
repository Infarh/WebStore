using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Entities.ViewModels.Products
{
    public class BrandCompleteViewModel
    {
        public IEnumerable<BrandViewModel> Brands { get; set; }

        public int? CurrentBrandId { get; set; }
    }
}
