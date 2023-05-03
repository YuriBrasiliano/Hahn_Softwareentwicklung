using ErrorOr;
using Hahn_Softwareentwicklung.Application.Common.Interfaces.Authentication;
using Hahn_Softwareentwicklung.Application.Common.Interfaces.Persistence;
using Hahn_Softwareentwicklung.Domain.Entities;
using Hahn_Softwareentwicklung.Domain.Common.Errors;
using MediatR;
using Hahn_Softwareentwicklung.Application.Authentication.Common;

namespace Hahn_Softwareentwicklung.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
         //1. Make sure the user exists
        if(_userRepository.GetUserByEmail(query.Email) is not User user)
        {
           return Errors.Authentication.InvalidCredentials;
        }

        //2. Validade the password
        if(user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        //3. Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(user, token);
    }
}