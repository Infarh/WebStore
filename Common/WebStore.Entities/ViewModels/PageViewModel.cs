using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Entities.ViewModels
{
    /// <summary>Модель построничного разбиения</summary>
    public class PageViewModel
    {
        /// <summary>Общее число элементов</summary>
        public int TotalItems { get; set; }

        /// <summary>Количество элементов на странице</summary>
        public int PageSize { get; set; }

        /// <summary>Номер текущей страницы</summary>
        public int PageNumber { get; set; }

        /// <summary>Общее количество страниц</summary>
        public int TotalPages => (int) Math.Ceiling((decimal) TotalItems / PageSize);
    }
}
