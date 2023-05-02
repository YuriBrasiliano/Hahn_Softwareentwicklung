using Hahn_Softwareentwicklung.Application.Common.Interfaces.Authentication;
using Hahn_Softwareentwicklung.Application.Common.Interfaces.Persistence;
using Hahn_Softwareentwicklung.Domain.Entities;

namespace Hahn_Softwareentwicklung.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validate User Exists
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User does not exist!");
        }

        //2. Validate the password
        if(user.Password != password)
        {
            throw new Exception ("Invalid Password");
        }

        //3. Create Token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
        
        return new AuthenticationResult(user.Id, user.FirstName, user.LastName, email, token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Validate user does not already exists
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User already exists!");
        }

        //Create user (generate unique ID)
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        //Create the token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);


        return new AuthenticationResult(user.Id, firstName, lastName, email, token);
    }
}