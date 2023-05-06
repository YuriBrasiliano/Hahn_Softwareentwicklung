using Hahn_Softwareentwicklung.Application.Authentication.Commands.Register;
using Hahn_Softwareentwicklung.Application.Authentication.Common;
using Hahn_Softwareentwicklung.Application.Authentication.Queries.Login;
using Hahn_Softwareentwicklung.Contracts.Authentication;
using Mapster;

namespace Hahn_Softwareentwicklung.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest, src => src.User);
    }
}