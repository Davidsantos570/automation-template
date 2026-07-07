using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zitec.Automation.Application.Services;

namespace Zitec.Automation.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IAutomacaoExecutorService, AutomacaoExecutorService>();

        return services;
    }
}
