using System;

namespace WebStore.Entities.DTO.User
{
    public class SetLockoutDTO : UserBaseDTO
    {
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}