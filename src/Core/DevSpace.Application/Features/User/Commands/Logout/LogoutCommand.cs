using DevSpace.Application.Common.Models.Results;
using Mediator;

namespace DevSpace.Application.Features.User.Commands.Logout;

public record LogoutCommand(int UserId) : IRequest<OperationResult<bool>>;
