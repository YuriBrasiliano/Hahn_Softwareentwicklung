using Hahn_Softwareentwicklung.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn_Softwareentwicklung.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}