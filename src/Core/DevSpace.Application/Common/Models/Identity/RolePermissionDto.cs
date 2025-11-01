using DevSpace.Domain.Identity;

namespace DevSpace.Application.Common.Models.Identity;

public class RolePermissionDto
{
    public List<string> Keys { get; set; } = [];

    public Role Role { get; set; } = default!;

    public int RoleId { get; set; }

    public List<ActionDescriptionDto> Actions { get; set; } = default!;
}
