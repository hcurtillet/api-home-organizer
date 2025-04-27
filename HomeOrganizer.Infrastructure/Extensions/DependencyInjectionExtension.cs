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
        services.AddScoped<ISaveChangesInterceptor, DispatchDomaineventInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, AuditInterceptor>();
        services.AddDbContext<HomeOrganizerContext>(options =>
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            
            );
        
        services.AddScoped<IHomeOrganizerContext>(provider => provider.GetRequiredService<HomeOrganizerContext>());

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        services.AddScoped<IIdentityService, IdentityService>();
        
        return services;
    }
}