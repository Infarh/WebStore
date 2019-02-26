using System.Security.Claims;

namespace WebStore.Entities.DTO.User
{
    public class ReplaceClaimDTO : UserBaseDTO
    {
        public Claim OldClaim { get; set; }
        public Claim NewClaim { get; set; }
    }
}