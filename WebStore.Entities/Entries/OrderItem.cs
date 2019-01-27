using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Text;
using WebStore.Entities.Entries.Base;

namespace WebStore.Entities.Entries
{
    public class OrderItem : BaseEntry
    {
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
