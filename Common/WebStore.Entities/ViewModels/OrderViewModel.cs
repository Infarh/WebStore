using System.ComponentModel.DataAnnotations;

namespace WebStore.Entities.ViewModels
{
    /// <summary>Модель-представление заказа</summary>
    public class OrderViewModel
    {
        /// <summary>Имя</summary>
        [Required, Display(Name = "Имя")]
        public string Name { get; set; }

        /// <summary>Телефон</summary>
        [Required, DataType(DataType.PhoneNumber), Display(Name="Телефон")]
        public string Phone { get; set; }

        /// <summary>Адрес</summary>
        [Required, Display(Name="Адрес")]
        public string Address { get; set; }
    }
}
