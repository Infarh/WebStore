namespace WebStore.Entities.Entries.Base.Interfaces
{
    /// <summary>Именованная сущность</summary>
    public interface INamedEntry : IBaseEntry
    {
        /// <summary>Имя</summary>
        string Name { get; set; }
    }
}