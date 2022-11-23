using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Implementation;
using Service.Interface;
using static Service.ViewModels.Coach.LoginRequestViewModel;

namespace Service.Configuration;

public static class ServiceConfiguration
{
    public static void AddServiceConfigurations(this IServiceCollection services)
    {
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<ICoachService, CoachService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IGenderService, GenderService>();

        services.AddFluentValidationAutoValidation();
    }
}
