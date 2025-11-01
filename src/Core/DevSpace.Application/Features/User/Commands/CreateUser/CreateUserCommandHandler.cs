using AutoMapper;
using DevSpace.Application.Common.Contracts.Identity;
using DevSpace.Application.Common.Models.Results;
using Mediator;
using Microsoft.Extensions.Logging;

namespace DevSpace.Application.Features.User.Commands.CreateUser;

internal class CreateUserCommandHandler(
    IApplicationUserManager userManager,
    IMapper mapper,
    ILogger<CreateUserCommandHandler> logger
) : IRequestHandler<CreateUserCommand, OperationResult<CreateUserResult>>
{
    public async ValueTask<OperationResult<CreateUserResult>> Handle(CreateUserCommand req, CancellationToken ct)
    {
        var phoneNumberExist = await userManager.IsExistUser(req.PhoneNumber);

        if (phoneNumberExist)
            return OperationResult<CreateUserResult>.FailureResult("Phone number already exists.", default);

        var userNameExist = await userManager.IsExistUserName(req.UserName);

        if (userNameExist)
            return OperationResult<CreateUserResult>.FailureResult("Username already exists.", default);

        var user = mapper.Map<Domain.Identity.User>(req);

        var createResult = await userManager.CreateUser(user);

        if (!createResult.Succeeded)
            return OperationResult<CreateUserResult>.FailureResult(string.Join(",", createResult.Errors.Select(c => c.Description)), default);

        var code = await userManager.GeneratePhoneNumberConfirmationToken(user, user.PhoneNumber);

        // ToDo: Send Code via SMS Provider
        logger.LogWarning($"Generated Code for User ID {user.Id} is {code}");

        return OperationResult<CreateUserResult>.SuccessResult(new CreateUserResult { UserGeneratedKey = user.GeneratedCode });
    }
}
