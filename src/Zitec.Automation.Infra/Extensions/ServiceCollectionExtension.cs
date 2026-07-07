using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zitec.Automation.Infra.DataContext;
using Zitec.Automation.Infra.Repositories;

namespace Zitec.Automation.Infra.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContextPool<AutomationDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("SQLConnection"), sqlOptions =>
            {
                sqlOptions.CommandTimeout(60);
            });
        }, poolSize: 32);

        services.AddScoped<DbContext, AutomationDbContext>();
        services.AddScoped<IItemProcessadoRepository, ItemProcessadoRepository>();

        return services;
    }
}
