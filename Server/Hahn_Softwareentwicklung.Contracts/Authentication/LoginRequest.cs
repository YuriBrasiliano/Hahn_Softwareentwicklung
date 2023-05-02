namespace Hahn_Softwareentwicklung.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password
);