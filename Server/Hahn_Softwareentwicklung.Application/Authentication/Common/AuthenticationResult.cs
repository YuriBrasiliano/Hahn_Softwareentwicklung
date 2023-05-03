using Hahn_Softwareentwicklung.Domain.Entities;

namespace Hahn_Softwareentwicklung.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);