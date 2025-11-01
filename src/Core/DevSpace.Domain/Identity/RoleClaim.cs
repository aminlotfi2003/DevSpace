using Microsoft.AspNetCore.Identity;

namespace DevSpace.Domain.Identity;

public class RoleClaim : IdentityRoleClaim<int>
{
    public Role Role { get; set; } = default!;
    
    public DateTimeOffset CreatedOn { get; set; }

    public RoleClaim()
    {
        CreatedOn = DateTimeOffset.UtcNow;
    }
}
