using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Infrastructure.Authentication;
using HomeOrganizer.Infrastructure.Context;
using HomeOrganizer.Infrastructure.Dao;
using HomeOrganizer.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeOrganizer.Infrastructure.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ISaveChangesInterceptor, AuditInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomaineventInterceptor>();
        services.AddDbContext<HomeOrganizerContext>((sp, options) =>
        {

            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
        
        services.AddScoped<IHomeOrganizerContext>(provider => provider.GetRequiredService<HomeOrganizerContext>());

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        return services;
    }
}