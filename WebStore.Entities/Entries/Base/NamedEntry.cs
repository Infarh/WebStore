using WebStore.Entities.Entries.Base.Interfaces;

namespace WebStore.Entities.Entries.Base
{
    /// <summary>Именованная сущность</summary>
    public abstract class NamedEntry : INamedEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}