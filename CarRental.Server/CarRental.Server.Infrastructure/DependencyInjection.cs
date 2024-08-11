using CarRental.Server.Domain.Users;
using CarRental.Server.Infrastructure.BackgroundServices;
using CarRental.Server.Infrastructure.Contexts;
using CarRental.Server.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Nlabs.GenericRepository;
using Scrutor;
using System.Reflection;

namespace CarRental.Server.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //Default Connection String
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultSqlServer"));
        });
        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

        //Cars Connection String
        services.AddDbContext<CarDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CarSqlServer"));
        });
        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<CarDbContext>());

        //Blogs Connection String
        services.AddDbContext<BlogDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("BlogSqlServer"));
        });
        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<BlogDbContext>());


        services
            .AddIdentity<AppUser, AppRole>(cfr =>
            {
                cfr.Password.RequiredLength = 1;
                cfr.Password.RequireNonAlphanumeric = false;
                cfr.Password.RequireUppercase = false;
                cfr.Password.RequireLowercase = false;
                cfr.Password.RequireDigit = false;
                cfr.SignIn.RequireConfirmedEmail = true;
                cfr.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                cfr.Lockout.MaxFailedAccessAttempts = 3;
                cfr.Lockout.AllowedForNewUsers = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.ConfigureOptions<JwtTokenOptionsSetup>();
        services.AddAuthentication()
            .AddJwtBearer();
        services.AddAuthorizationBuilder();

        services.Scan(action =>
        {
            action
            .FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .AsImplementedInterfaces()
            .WithScopedLifetime();
        });

        services.AddHealthChecks()
            .AddCheck("health-check", () => HealthCheckResult.Healthy())
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddHttpClient();

        services.AddHostedService<HealthCheckBackgroundService>();

        return services;
    }
}