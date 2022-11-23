using Microsoft.Extensions.DependencyInjection;
using Service.Implementation;
using Service.Interface;

namespace Service.Configuration;

public static class ServiceConfiguration
{
    public static void AddServiceConfigurations(this IServiceCollection services)
    {
        services.AddScoped<ICoachService, CoachService>();
        services.AddScoped<IGenderService, GenderService>();
    }
}
