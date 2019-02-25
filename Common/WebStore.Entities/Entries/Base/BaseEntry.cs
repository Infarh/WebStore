using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Entities.Entries.Base.Interfaces;

namespace WebStore.Entities.Entries.Base
{
    /// <summary>Сущность</summary>
    public abstract class BaseEntry : IBaseEntry
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}