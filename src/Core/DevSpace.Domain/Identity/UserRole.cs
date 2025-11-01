using Microsoft.AspNetCore.Identity;

namespace DevSpace.Domain.Identity;

public class UserRole : IdentityUserRole<int>
{
    public User User { get; set; } = default!;
    public Role Role { get; set; } = default!;
    
    public DateTimeOffset CreatedOn { get; set; }

    public UserRole()
    {
        CreatedOn = DateTimeOffset.UtcNow;
    }
}
