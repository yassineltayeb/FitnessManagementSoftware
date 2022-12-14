using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Service.Filters;
using Microsoft.ApplicationInsights.DependencyCollector;
using Quartz;
using Service.BackgroundJobs;

namespace Service.Configuration;

public static class CommonConfiguration
{
    public static void AddCommonConfigurations(this IServiceCollection services)
    {
        // Filters
        services.AddMvc(option =>
        {
            option.Filters.Add<ModelStateValidationFilter>();
            option.Filters.Add<HttpResponseExceptionFilter>();
        });

        // Fluent Validation
        services.AddFluentValidationAutoValidation();

        // Global Error Handling
        services.AddApplicationInsightsTelemetry();
        services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, _) =>
        {
            module.EnableSqlCommandTextInstrumentation = true;
        });

        // Quartz

        services.AddQuartz(configure => 
        {
            var jobKey = new JobKey(nameof(UpdateCoachClassStatusJob));

            configure
                .AddJob<UpdateCoachClassStatusJob>(jobKey)
                .AddTrigger(trigger => trigger.ForJob(jobKey).WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(3).RepeatForever()));

            configure.UseMicrosoftDependencyInjectionJobFactory();
        });

        services.AddQuartzHostedService();
    }
}
