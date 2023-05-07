using Hahn_Softwareentwicklung.Application.Authentication.Common;
using Hahn_Softwareentwicklung.Contracts.Authentication;
using Hahn_Softwareentwicklung.Application.Authentication.Commands.Register;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

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

        var query = _mapper.Map<RegisterCommand>(request);
        
        var authResult = await _mediator.Send(query);       
        
        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }
}