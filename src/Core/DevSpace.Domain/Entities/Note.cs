using DevSpace.Domain.Common;
using DevSpace.Domain.Identity;

namespace DevSpace.Domain.Entities;

public class Note : EntityBase
{
    public int OwnerId { get; set; }
    public User User { get; set; } = default!;

    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;

    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
}
