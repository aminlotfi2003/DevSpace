using DevSpace.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DevSpace.Domain.Identity;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string GeneratedCode { get; set; } = default!;

    public User()
    {
        GeneratedCode = Guid.NewGuid().ToString().Substring(0, 8);
    }

    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    public ICollection<UserLogin> Logins { get; set; } = new HashSet<UserLogin>();
    public ICollection<UserClaim> Claims { get; set; } = new HashSet<UserClaim>();
    public ICollection<UserToken> Tokens { get; set; } = new HashSet<UserToken>();
    public ICollection<UserRefreshToken> UserRefreshTokens { get; set; } = new HashSet<UserRefreshToken>();

    public ICollection<Note> Notes { get; set; } = new HashSet<Note>();
    public ICollection<Snippet> Snippets { get; set; } = new HashSet<Snippet>();
    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
}
