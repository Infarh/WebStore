using System.Collections.Generic;
using WebStore.Entities.Entries.Base.Interfaces;

namespace WebStore.Entities.ViewModels.Products
{
    public class SectionViewModel : INamedEntry, IOrderedEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        /// <summary>Дочерние секции</summary>
        public List<SectionViewModel> ChildSections { get; set; } = new List<SectionViewModel>();

        /// <summary>Родительская секция</summary>
        public SectionViewModel ParentSection { get; set; }
    }
}
