using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Entities.Entries;
using WebStore.Entities.ViewModels;

namespace WebStore.Services.Map
{
    public static class Brand2BrandViewModel
    {
        public static BrandViewModel Map(this Brand brand) => new BrandViewModel
        {
            Id = brand.Id,
            Name = brand.Name,
            Order = brand.Order
        };
    }
}
