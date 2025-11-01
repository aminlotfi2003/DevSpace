using DevSpace.Application.Common.Contracts.Identity;
using DevSpace.Application.Common.Models.Results;
using Mediator;

namespace DevSpace.Application.Features.User.Commands.Logout;

internal class LogoutCommandHandler(IApplicationUserManager userManager)
    : IRequestHandler<LogoutCommand, OperationResult<bool>>
{
    public async ValueTask<OperationResult<bool>> Handle(LogoutCommand req, CancellationToken ct)
    {
        var user = await userManager.GetUserByIdAsync(req.UserId, ct);

        if (user is null)
            return OperationResult<bool>.NotFoundResult("User not found.");

        await userManager.UpdateSecurityStampAsync(user, ct);

        return OperationResult<bool>.SuccessResult(true);
    }
}
