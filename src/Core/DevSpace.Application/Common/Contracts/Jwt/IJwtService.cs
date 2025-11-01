using DevSpace.Application.Common.Models.Jwt;
using DevSpace.Domain.Identity;
using System.Security.Claims;

namespace DevSpace.Application.Common.Contracts.Jwt;

public interface IJwtService
{
    Task<AccessToken> GenerateAsync(User user);
    Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    Task<AccessToken> GenerateByPhoneNumberAsync(string phoneNumber);
    Task<AccessToken> RefreshToken(Guid refreshTokenId);
}
