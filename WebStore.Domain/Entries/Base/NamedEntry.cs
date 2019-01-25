using WebStore.Domain.Entries.Base.Interfaces;

namespace WebStore.Domain.Entries.Base
{
    /// <summary>Именованная сущность</summary>
    public abstract class NamedEntry : INamedEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}