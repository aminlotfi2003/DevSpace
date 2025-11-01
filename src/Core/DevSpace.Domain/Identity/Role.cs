using Microsoft.AspNetCore.Identity;

namespace DevSpace.Domain.Identity;

public class Role : IdentityRole<int>
{
    public string DisplayName { get; set; } = null!;
    public DateTimeOffset CreatedOn { get; set; }

    public Role()
    {
        CreatedOn = DateTimeOffset.UtcNow;
    }
    
    public ICollection<RoleClaim> Claims { get; set; } = new HashSet<RoleClaim>();
}
