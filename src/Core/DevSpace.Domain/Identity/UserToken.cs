using Microsoft.AspNetCore.Identity;

namespace DevSpace.Domain.Identity;

public class UserToken : IdentityUserToken<int>
{
    public User User { get; set; } = default!;

    public DateTimeOffset GeneratedOn { get; set; }

    public UserToken()
    {
        GeneratedOn = DateTimeOffset.UtcNow;
    }
}
