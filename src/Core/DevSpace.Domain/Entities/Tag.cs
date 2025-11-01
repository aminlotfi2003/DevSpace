using DevSpace.Domain.Common;
using DevSpace.Domain.Identity;

namespace DevSpace.Domain.Entities;

public class Tag : EntityBase
{
    public int OwnerId { get; set; }
    public User User { get; set; } = default!;

    public string Name { get; set; } = null!;

    public ICollection<Note> Notes { get; set; } = new HashSet<Note>();
    public ICollection<Snippet> Snippets { get; set; } = new HashSet<Snippet>();
}
