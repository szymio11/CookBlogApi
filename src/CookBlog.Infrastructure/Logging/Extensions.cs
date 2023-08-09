using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Infrastructure.Logging.Decorators;
using Microsoft.Extensions.DependencyInjection;

namespace CookBlog.Api.Infrastructure.Logging;

internal static class Extensions
{
    public static IServiceCollection AddCustomLogging(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

        return services;
    }
}
