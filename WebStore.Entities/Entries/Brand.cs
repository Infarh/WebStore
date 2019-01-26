using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Entities.Entries.Base;
using WebStore.Entities.Entries.Base.Interfaces;

namespace WebStore.Entities.Entries
{
    /// <summary>Бренд</summary>
    [Table("Brands")]
    public class Brand : NamedEntry, IOrderedEntry
    {
        public int Order { get; set; }
    }
}