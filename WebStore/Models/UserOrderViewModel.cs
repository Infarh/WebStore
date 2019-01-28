namespace WebStore.Models
{
    /// <summary>Модель представления заказа пользователя</summary>
    public class UserOrderViewModel
    {
        /// <summary>Идентификатор</summary>
        public int Id { get; set; }

        /// <summary>Имя пользователя</summary>
        public string Name { get; set; }

        /// <summary>Телефон</summary>
        public string Phone { get; set; }

        /// <summary>Адрес</summary>
        public string Address { get; set; }

        /// <summary>Сумма заказа</summary>
        public decimal TotalSum { get; set; }
    }
}
