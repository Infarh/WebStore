using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.Entries;
using WebStore.Entities.ViewModels;
using WebStore.Entities.ViewModels.Products;
using WebStore.Interfaces.Services;
using WebStore.Services.Map;

namespace WebStore.Components
{
    public class SectionsViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;

        public SectionsViewComponent(IProductData ProductData) => _ProductData = ProductData;

        public IViewComponentResult Invoke(string SectionId)
        {
            var current_section_id = int.TryParse(SectionId, out var id) ? id : (int?)null;
            var sections = GetSections(current_section_id, out var parent_section_id);
            return View(new SectionCompleteViewModel
            {
                Sections = sections,
                CurrentSectionId = current_section_id,
                CurrentParentSectionId = parent_section_id
            });
        }

        private IEnumerable<SectionViewModel> GetSections(int? SectionId, out int? ParentSectionId)
        {
            ParentSectionId = null;
            var sections = _ProductData.GetSections().ToArray();

            var parent_sections = sections
                .Where(section => section.ParentId is null)
                .Select(Section => Section.Map())
                .ToList();

            foreach (var parent_section in parent_sections)
            {
                var child_sections = sections
                    .Where(section => section.ParentId == parent_section.Id)
                    .Select(section => section.Map());
                foreach (var child_section in child_sections)
                {
                    if (child_section.Id == SectionId)
                        ParentSectionId = parent_section.Id;
                    parent_section.ChildSections.Add(child_section);
                }
                parent_section.ChildSections.Sort((a,b) => Comparer<int>.Default.Compare(a.Order, b.Order));
            }
            parent_sections.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order));
            return parent_sections;
        }
    }
}
