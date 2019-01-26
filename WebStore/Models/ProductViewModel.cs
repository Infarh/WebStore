using System;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Entities.Entries.Base.Interfaces;

namespace WebStore.Models
{
    public class ProductViewModel : INamedEntry, IOrderedEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
