using Hahn_Softwareentwicklung.Domain.Entities;

namespace Hahn_Softwareentwicklung.Application.Services.Authentication;

public record AuthenticationResult
(
    User User,
    string Token
);