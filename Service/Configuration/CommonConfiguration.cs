using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Service.Filters;
using Microsoft.ApplicationInsights.DependencyCollector;

namespace Service.Configuration;

public static class CommonConfiguration
{
    public static void AddCommonConfigurations(this IServiceCollection services)
    {
        // Filters
        services.AddMvc(option =>
        {
            option.Filters.Add<HttpResponseExceptionFilter>();
        });

        // Fluent Validation
        services.AddFluentValidationAutoValidation();

        // 
        services.AddApplicationInsightsTelemetry();
        services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, _) =>
        {
            module.EnableSqlCommandTextInstrumentation = true;
        });
    }
}
