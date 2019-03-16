using System.Collections.Generic;

namespace WebStore.Entities.ViewModels.Products
{
    public class SectionCompleteViewModel
    {
        public IEnumerable<SectionViewModel> Sections { get; set; }

        public int? CurrentParentSectionId { get; set; }

        public int? CurrentSectionId { get; set; }
    }
}
