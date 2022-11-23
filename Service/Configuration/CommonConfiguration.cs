using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Service.Filters;

namespace Service.Configuration;

public static class CommonConfiguration
{
    public static void AddCommonConfigurations(this IServiceCollection services)
    {
        services.AddMvc(option =>
        {
            option.Filters.Add<HttpResponseExceptionFilter>();
        });

        services.AddFluentValidationAutoValidation();
    }
}
