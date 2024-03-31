using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using TestersManager.Infrastructure.DbContext;

namespace TestersManager.IntegrationsTests;

public class CustomWebAppFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");

        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(x =>
                x.ServiceType == typeof(DbContextOptions<ApplicatonDbContext>));

            if (descriptor != null) services.Remove(descriptor);

            services.AddDbContext<ApplicatonDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
        });
    }
}