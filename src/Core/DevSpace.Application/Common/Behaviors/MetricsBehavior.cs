#nullable disable

using Mediator;
using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace DevSpace.Application.Common.Behaviors;

public class MetricsBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly Histogram<long> _requestResponseDurationHistogram;

    public MetricsBehavior(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create("mediator_meter");
        _requestResponseDurationHistogram = meter.CreateHistogram<long>(
            "Request_Response_Duration", "ms", "Determines the total request response durations"
        );
    }

    public async ValueTask<TResponse> Handle(TRequest message, MessageHandlerDelegate<TRequest, TResponse> next, CancellationToken cancellationToken)
    {
        var stopWatch = Stopwatch.StartNew();

        var response = await next(message, cancellationToken);

        stopWatch.Stop();

        _requestResponseDurationHistogram.Record(stopWatch.ElapsedMilliseconds, new[] { new KeyValuePair<string, object>("Request", message.GetType().Name) });

        return response;
    }
}
