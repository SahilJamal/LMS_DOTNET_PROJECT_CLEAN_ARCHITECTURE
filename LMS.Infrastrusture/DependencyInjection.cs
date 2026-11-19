using LMS.Application.Interfaces.Repositories;
using LMS.Infrastructure.Repositories;
using LMS.Application.Interfaces.Services;
using LMS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using LMS.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "MySQL connection string is missing.");
        }

        services.AddDbContext<AppDbContext>(options =>
            options.UseMySQL(connectionString));

	//Repositories
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Services
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();

        return services;
    }
}
