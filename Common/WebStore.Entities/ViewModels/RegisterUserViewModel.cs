using System.ComponentModel.DataAnnotations;

namespace WebStore.Entities.ViewModels
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
