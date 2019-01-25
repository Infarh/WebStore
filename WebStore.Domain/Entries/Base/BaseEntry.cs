using WebStore.Domain.Entries.Base.Interfaces;

namespace WebStore.Domain.Entries.Base
{
    /// <summary>Сущность</summary>
    public abstract class BaseEntry : IBaseEntry
    {
        public int Id { get; set; }
    }
}