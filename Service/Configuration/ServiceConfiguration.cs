using Microsoft.Extensions.DependencyInjection;
using Service.Implementation;
using Service.Interface;

namespace Service.Configuration;

public static class ServiceConfiguration
{
    public static void AddServiceConfigurations(this IServiceCollection services)
    {
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<ICoachService, CoachService>();
        services.AddScoped<ICoachTypeService, CoachTypeService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IGenderService, GenderService>();
        services.AddScoped<IMemberService, MemberService>();
    }
}
