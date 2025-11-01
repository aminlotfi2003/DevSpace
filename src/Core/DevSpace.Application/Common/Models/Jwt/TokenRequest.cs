using System.ComponentModel.DataAnnotations;

namespace DevSpace.Application.Common.Models.Jwt;

public class TokenRequest
{
    [Required]
    public string Grant_Type { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Refresh_Token { get; set; } = default!;
    public string Scope { get; set; } = default!;
    public string Client_Id { get; set; } = default!;
    public string Client_Secret { get; set; } = default!;
}
