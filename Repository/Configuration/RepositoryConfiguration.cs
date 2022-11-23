using Microsoft.Extensions.DependencyInjection;
using Repository.Implementation;
using Repository.Interface;

namespace Repository.Configuration;

public static class RepositoryConfiguration
{
    public static void AddRepositoryConfigurations(this IServiceCollection services)
    {
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICoachRepository, CoachRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IGenderRepository, GenderRepository>();
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
    }
}
