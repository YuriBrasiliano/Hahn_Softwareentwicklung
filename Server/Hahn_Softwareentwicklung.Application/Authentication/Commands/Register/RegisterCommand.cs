using ErrorOr;
using Hahn_Softwareentwicklung.Application.Authentication.Common;
using MediatR;

namespace Hahn_Softwareentwicklung.Application.Authentication.Commands.Register;

public record RegisterCommand
(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;