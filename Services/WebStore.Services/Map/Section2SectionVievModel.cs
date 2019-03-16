using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Entities.Entries;
using WebStore.Entities.ViewModels.Products;

namespace WebStore.Services.Map
{
    public static class Section2SectionVievModel
    {
        public static SectionViewModel Map(this Section section, SectionViewModel ParentSection = null) => new SectionViewModel
        {
            Id = section.Id,
            Name = section.Name,
            Order = section.Order,
            ParentSection = ParentSection
        };
    }
}
