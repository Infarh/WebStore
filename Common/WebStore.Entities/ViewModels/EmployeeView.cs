using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Entities.ViewModels
{
    /// <summary>Модель-представление сущности "Работник"</summary>
    public class EmployeeView
    {
        /// <summary>Идентификатор</summary>
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>Имя</summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Отсутствует указание имени")]
        [Display(Name = "Имя")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 200 символов")]
        public string FirstName { get; set; }

        /// <summary>Фамилия</summary>
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        /// <summary>Отчество</summary>
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        /// <summary>Возраст</summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Возраст не указан")]
        [Display(Name = "Возраст")]
        [Range(16, 160, ErrorMessage = "Возраст сотрудника должен быть в пределах от 16 до 160 лет")]
        public int Age { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Не указана должность")]
        [Display(Name = "Должность")]
        public string Position { get; set; }
    }
}
