using DevSpace.Application.Common.Models.Jwt;
using DevSpace.Application.Common.Models.Results;
using DevSpace.SharedKernel.Extensions;
using FluentValidation;
using Mediator;

namespace DevSpace.Application.Features.User.Commands.RefreshToken;

public record UserRefreshTokenCommand(Guid RefreshToken)
    : IRequest<OperationResult<AccessToken>>, IValidatableModel<UserRefreshTokenCommand>
{
    public IValidator<UserRefreshTokenCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserRefreshTokenCommand> validator)
    {
        validator.RuleFor(c => c.RefreshToken)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter valid user refresh token");

        return validator;
    }
}
