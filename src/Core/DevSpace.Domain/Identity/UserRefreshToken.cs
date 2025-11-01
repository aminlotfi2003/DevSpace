using DevSpace.Domain.Common;

namespace DevSpace.Domain.Identity;

public class UserRefreshToken : EntityBase<Guid>
{
    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public bool IsValid { get; set; }

    public UserRefreshToken()
    {
        CreatedOn = DateTimeOffset.UtcNow;
    }
}
