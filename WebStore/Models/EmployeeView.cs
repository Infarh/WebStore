namespace WebStore.Models
{
    /// <summary>Модель-представление сущности "Работник"</summary>
    public class EmployeeView
    {
        /// <summary>Идентификатор</summary>
        public int Id { get; set; }
        /// <summary>Имя</summary>
        public string FirstName { get; set; }
        /// <summary>Фамилия</summary>
        public string LastName { get; set; }
        /// <summary>Отчество</summary>
        public string Patronymic { get; set; }
        /// <summary>Возраст</summary>
        public int Age { get; set; }
    }
}
