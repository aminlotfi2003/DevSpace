using DevSpace.Application.Common.Profiles;
using DevSpace.Domain.Identity;

namespace DevSpace.Application.Common.Models.Identity;

public class GetRolesDto : ICreateMapper<Role>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}
