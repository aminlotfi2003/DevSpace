using DevSpace.Domain.Common;
using DevSpace.Domain.Identity;

namespace DevSpace.Domain.Entities;

public class Snippet : EntityBase
{
    public int OwnerId { get; set; }
    public User User { get; set; } = default!;

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public CodeLanguage Language { get; set; }
    public string Code { get; set; } = null!;

    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
}

public enum CodeLanguage
{
    CSharp = 0,
    Other = 99
}
