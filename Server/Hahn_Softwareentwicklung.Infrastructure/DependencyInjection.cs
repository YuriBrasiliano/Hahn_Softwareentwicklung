using Hahn_Softwareentwicklung.Application.Common.Interfaces.Authentication;
using Hahn_Softwareentwicklung.Application.Common.Interfaces.Services;
using Hahn_Softwareentwicklung.Infrastructure.Authentication;
using Hahn_Softwareentwicklung.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn_Softwareentwicklung.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}