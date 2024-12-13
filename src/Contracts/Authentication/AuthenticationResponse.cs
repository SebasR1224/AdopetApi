namespace Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string? FoundationId,
    string Name,
    string LastName,
    string Username,
    string Email,
    string Token);
