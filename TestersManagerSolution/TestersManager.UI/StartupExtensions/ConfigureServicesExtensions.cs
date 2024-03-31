using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using TestersManager.Core.Domain.RepositoryContracts;
using TestersManager.Core.ServiceContracts;
using TestersManager.Core.Services;
using TestersManager.Infrastructure.DbContext;
using TestersManager.Infrastructure.Repositories;
using TestersManager.UI.Filters.ActionFilters;

namespace TestersManager.UI.StartupExtensions;

public static class ConfigureServicesExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ResponseHeaderActionFilter>();

        var logger = services.BuildServiceProvider().GetRequiredService<ILogger<ResponseHeaderActionFilter>>();

        services.AddControllersWithViews(options =>
        {
            options.Filters.Add(new ResponseHeaderActionFilter(logger)
                { Key = "X-Custom-Key-Global", Value = "X-Custom-Value-Global", Order = 2 });
        });

        services.AddDbContext<ApplicatonDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddHttpLogging(logging =>
        {
            logging.LoggingFields =
                HttpLoggingFields.RequestPropertiesAndHeaders |
                HttpLoggingFields.RequestPropertiesAndHeaders;
        });

        services.AddScoped<IDevStreamsGetterService, DevStreamsGetterService>();
        services.AddScoped<IDevStreamsAdderService, DevStreamsAdderService>();
        services.AddScoped<ITestersGetterService, TestersGetterService>();
        services.AddScoped<ITestersAdderService, TestersAdderService>();
        services.AddScoped<ITestersSorterService, TestersSorterService>();
        services.AddScoped<ITestersDeleterService, TestersDeleterService>();
        services.AddScoped<ITestersUpdaterService, TestersUpdaterService>();

        services.AddScoped<IDevStreamsRepository, DevStreamsRepository>();
        services.AddScoped<ITestersRepository, TestersRepository>();

        return services;
    }
}