using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Entities.Entries.Base;
using WebStore.Entities.Entries.Base.Interfaces;

namespace WebStore.Entities.Entries
{
    /// <summary>Секция</summary>
    [Table("Sections")]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class Section : NamedEntry, IOrderedEntry
    {
        /// <summary>Родительская секция</summary>
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Section ParentSection { get; set; }

        public int Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
