using Microsoft.AspNetCore.Identity;

namespace DevSpace.Domain.Identity;

public class UserLogin : IdentityUserLogin<int>
{
    public User User { get; set; } = default!;
    
    public DateTimeOffset LoggedOn { get; set; }

    public UserLogin()
    {
        LoggedOn = DateTimeOffset.UtcNow;
    }
}
