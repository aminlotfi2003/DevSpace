#nullable disable

using DevSpace.Application.Common.Models.Results;
using Mediator;
using Microsoft.Extensions.Logging;

namespace DevSpace.Application.Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TResponse : class
    where TRequest : IRequest<TResponse>
{
    public async ValueTask<TResponse> Handle(TRequest message, MessageHandlerDelegate<TRequest, TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            var response = await next(message, cancellationToken);
            return response;
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);

            if (typeof(TResponse).GetGenericTypeDefinition() == typeof(OperationResult<>))
            {
                var response = new OperationResult<TResponse> { IsException = true };
                return response as TResponse;
            }

            return default;
        }
    }
}
