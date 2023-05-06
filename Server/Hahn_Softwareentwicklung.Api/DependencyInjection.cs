using Hahn_Softwareentwicklung.Api.Common.Errors;
using Hahn_Softwareentwicklung.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Hahn_Softwareentwicklung.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {        
        services.AddMappings();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, HahnProblemDetailsFactory>();
        return services;
    }
}