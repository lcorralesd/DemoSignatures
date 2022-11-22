using DemoSignatures.Helper;
using DemoSignatures.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DemoSignatures;

public static class DependencyContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient<IFileTypeVerifier, FileTypeVerifier>();

        return services;
    }
}
