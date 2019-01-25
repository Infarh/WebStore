using WebStore.Domain.Entries.Base;
using WebStore.Domain.Entries.Base.Interfaces;

namespace WebStore.Domain.Entries
{
    /// <summary>Бренд</summary>
    public class Brand : NamedEntry, IOrderedEntry
    {
        public int Order { get; set; }
    }
}