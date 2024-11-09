using System.Text;
using Amazon.S3;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Password;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Application.Common.Interfaces.Upload;
using Infrastructure.Authentication;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;
using Infrastructure.Services.Location;
using Infrastructure.Services.Password;
using Infrastructure.Services.Upload.Aws;
using Infrastructure.Services.Upload.LocalStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistence(configuration)
            .AddUploadServices(configuration)
            .AddServices();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReportAbandonmentRepository, ReportAbandonmentRepository>();
        services.AddScoped<IFoundationRepository, FoundationRepository>();
        services.AddScoped<IAnimalRepository, AnimalRepository>();
        services.AddScoped<IFileRecordRepository, FileRecordRepository>();

        return services;
    }

    private static IServiceCollection AddUploadServices(this IServiceCollection services, IConfiguration configuration)
    {
        var awsSettings = new AWSSettings();
        configuration.Bind(AWSSettings.SectionName, awsSettings);

        services.AddAWSService<IAmazonS3>();
        services.AddScoped<IFileStorageService, LocalFileStorageService>();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<ILocationService, LocationService>(); //TODO use google maps api
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)
                )
            });

        return services;
    }
}
