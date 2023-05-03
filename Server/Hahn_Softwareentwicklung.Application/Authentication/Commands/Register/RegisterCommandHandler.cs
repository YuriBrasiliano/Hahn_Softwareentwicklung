using ErrorOr;
using Hahn_Softwareentwicklung.Application.Common.Interfaces.Authentication;
using Hahn_Softwareentwicklung.Application.Common.Interfaces.Persistence;
using Hahn_Softwareentwicklung.Domain.Entities;
using Hahn_Softwareentwicklung.Domain.Common.Errors;
using MediatR;
using Hahn_Softwareentwicklung.Application.Authentication.Common;

namespace Hahn_Softwareentwicklung.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
    
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        //1. Validate the user doest not exist
        if(_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        //2. Create user (generating unique ID) and Persiste to DB
        var user = new User{
            FirstName  = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.Add(user);


        //3.Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}