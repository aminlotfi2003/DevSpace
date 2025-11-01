using System.Reflection;
using DevSpace.Application.Common.Behaviors;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace DevSpace.Application.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Scoped;
            options.Namespace = "DevSpace.Application.Mediator";
        });

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MetricsBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateCommandBehavior<,>));


        services.AddAutoMapper(expression =>
        {
            expression.AddMaps(Assembly.GetExecutingAssembly());
        });


        return services;
    }
}
