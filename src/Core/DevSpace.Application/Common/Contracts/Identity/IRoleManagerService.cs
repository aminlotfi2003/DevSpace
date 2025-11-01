using DevSpace.Application.Common.Models.Identity;
using DevSpace.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DevSpace.Application.Common.Contracts.Identity;

public interface IRoleManagerService
{
    Task<List<GetRolesDto>> GetRolesAsync();
    Task<IdentityResult> CreateRoleAsync(CreateRoleDto model);
    Task<bool> DeleteRoleAsync(int roleId);
    Task<List<ActionDescriptionDto>> GetPermissionActionsAsync();
    Task<RolePermissionDto> GetRolePermissionsAsync(int roleId);
    Task<bool> ChangeRolePermissionsAsync(EditRolePermissionsDto model);
    Task<Role> GetRoleByIdAsync(int roleId);
}
