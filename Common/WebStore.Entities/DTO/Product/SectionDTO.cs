using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Entities.Entries.Base;
using WebStore.Entities.Entries.Base.Interfaces;

namespace WebStore.Entities.DTO.Product
{
    public class SectionDTO : INamedEntry
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
