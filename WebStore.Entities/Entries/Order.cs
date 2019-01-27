using System;
using System.Collections.Generic;
using WebStore.Entities.Entries.Base;
using WebStore.Entities.Identity;

namespace WebStore.Entities.Entries
{
    public class Order : NamedEntry
    {
        public virtual User User { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<OrderItem> Orders { get; set; } = new HashSet<OrderItem>();
    }
}