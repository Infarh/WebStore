using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Entities.Entries.Base.Interfaces;

namespace WebStore.Models
{
    public class BrandViewModel : INamedEntry, IOrderedEntry
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>Количества товаров бренда</summary>
        public int ProductsCount { get; set; }

        public int Order { get; set; }
    }
}
