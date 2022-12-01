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
        services.AddScoped<ICoachTypeRepository, CoachTypeRepository>();
        services.AddScoped<ICoachTypeRepository, CoachTypeRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IGenderRepository, GenderRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
