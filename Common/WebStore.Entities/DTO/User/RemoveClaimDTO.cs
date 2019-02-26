using System.Collections.Generic;
using System.Security.Claims;

namespace WebStore.Entities.DTO.User
{
    public class RemoveClaimDTO : UserBaseDTO
    {
        public IEnumerable<Claim> Claims { get; set; }
    }
}