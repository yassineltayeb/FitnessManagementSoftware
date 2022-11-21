using Microsoft.Extensions.DependencyInjection;
using Repository.Implementation;
using Repository.Interface;

namespace Repository.Configuration;

public static class RepositoryConfiguration
{
    public static void AddRepositoryConfigurations(this IServiceCollection services)
    {
        services.AddScoped<ICoachRepository, CoachRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
