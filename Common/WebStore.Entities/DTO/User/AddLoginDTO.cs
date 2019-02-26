using Microsoft.AspNetCore.Identity;

namespace WebStore.Entities.DTO.User
{
    public class AddLoginDTO : UserBaseDTO
    {
        public UserLoginInfo UserLoginInfo { get; set; }
    }
}