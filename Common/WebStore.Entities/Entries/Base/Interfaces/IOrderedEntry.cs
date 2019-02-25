namespace WebStore.Entities.Entries.Base.Interfaces
{
    /// <summary>Упорядоченная сущность</summary>
    public interface IOrderedEntry
    {
        /// <summary>Порядок</summary>
        int Order { get; set; }
    }
}