using System.IdentityModel.Tokens.Jwt;

namespace DevSpace.Application.Common.Models.Jwt;

public class AccessToken
{
    public string Access_Token { get; set; } = default!;
    public string Refresh_Token { get; set; } = default!;
    public string Token_Type { get; set; } = default!;
    public int Expires_In { get; set; }

    public AccessToken(JwtSecurityToken securityToken, string refreshToken = "")
    {
        Access_Token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        Refresh_Token = refreshToken;
        Token_Type = "Bearer";
        Expires_In = (int)(securityToken.ValidTo - DateTimeOffset.UtcNow).TotalSeconds;
    }
}
