using WebStore.Domain.Entries.Base;
using WebStore.Domain.Entries.Base.Interfaces;

namespace WebStore.Domain.Entries
{
    /// <summary>Секция</summary>
    public class Section : NamedEntry, IOrderedEntry
    {
        public int Order { get; set; }

        /// <summary>Родительская секция</summary>
        public int? ParentId { get; set; }
    }
}
