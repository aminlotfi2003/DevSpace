using Microsoft.AspNetCore.Identity;

namespace DevSpace.Domain.Identity;

public class UserClaim : IdentityUserClaim<int>
{
    public User User { get; set; } = default!;
}
