using DevSpace.Application.Common.Contracts.Jwt;
using DevSpace.Application.Common.Models.Jwt;
using DevSpace.Application.Common.Models.Results;
using Mediator;

namespace DevSpace.Application.Features.User.Commands.RefreshToken;

internal class UserRefreshTokenCommandHandler(IJwtService sve)
    : IRequestHandler<UserRefreshTokenCommand, OperationResult<AccessToken>>
{
    public async ValueTask<OperationResult<AccessToken>> Handle(UserRefreshTokenCommand req, CancellationToken ct)
    {
        var newToken = await sve.RefreshToken(req.RefreshToken);

        if (newToken is null)
            return OperationResult<AccessToken>.FailureResult("Invalid refresh token", default);

        return OperationResult<AccessToken>.SuccessResult(newToken);
    }
}
