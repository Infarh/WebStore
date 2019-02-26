using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebStore.Entities.DTO.User
{
    public class AddClaimDTO : UserBaseDTO
    {
        public IEnumerable<Claim> Claims { get; set; }
    }
}
