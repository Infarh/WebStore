using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Entities.Entries.Base.Interfaces;

namespace WebStore.Entities.DTO
{
    /// <summary>Объект для передачи данных <see cref="Entries.Brand"/> - бренда</summary>
    public class BrandDTO : INamedEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
