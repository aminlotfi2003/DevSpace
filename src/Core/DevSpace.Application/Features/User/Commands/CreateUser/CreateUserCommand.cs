using System.Text.RegularExpressions;
using DevSpace.Application.Common.Models.Results;
using DevSpace.Application.Common.Profiles;
using DevSpace.SharedKernel.Extensions;
using FluentValidation;
using Mediator;

namespace DevSpace.Application.Features.User.Commands.CreateUser;

public record CreateUserCommand(
    string UserName,
    string FirstName,
    string LastName,
    string PhoneNumber
) : IRequest<OperationResult<CreateUserResult>>
  , IValidatableModel<CreateUserCommand>
  , ICreateMapper<Domain.Identity.User>
{
    public IValidator<CreateUserCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CreateUserCommand> validator)
    {
        validator.RuleFor(c => c.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter your username");

        validator
            .RuleFor(src => src.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("User must have first name");

        validator
            .RuleFor(src => src.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage("User must have last name");

        validator.RuleFor(c => c.PhoneNumber).NotEmpty()
            .NotNull().WithMessage("Phone Number is required.")
            .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
            .Matches(new Regex(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$")).WithMessage("Phone number is not valid");

        return validator;
    }
}
