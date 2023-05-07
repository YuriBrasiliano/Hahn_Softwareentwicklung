using Hahn_Softwareentwicklung.Application.Authentication.Common;
using Hahn_Softwareentwicklung.Contracts.Authentication;
using Hahn_Softwareentwicklung.Application.Authentication.Commands.Register;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using Hahn_Softwareentwicklung.Domain.Common.Errors;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Hahn_Softwareentwicklung.Application.Authentication.Queries.Login;

namespace Hahn_Softwareentwicklung.Api.Controllers;

[Route("auth")]
[AllowAnonymous]

public class AuthenticationController : ApiController{

    private readonly ISender _mediator;

    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request){

        var query = _mapper.Map<LoginQuery>(request);
        
        var authResult = await _mediator.Send(query);

        if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description
            );
        }  
        
        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }
}