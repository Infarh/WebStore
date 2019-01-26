using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Имя пользователя является обязательным", AllowEmptyStrings = false), MaxLength(256, ErrorMessage = "Длина имени ограничена 256 символами")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Отсутствует пароль"), DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Отсутствует подтверждение пароля"), DataType(DataType.Password), Compare(nameof(Password))]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }
    }
}
