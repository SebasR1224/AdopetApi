namespace Contracts.Authentication;

public record RegisterRequest(
    Guid? FoundationId,
    string Name,
    string LastName,
    string PersonalId,
    DateOnly BirthDate,
    string PhoneNumber,
    string Address,
    string Email,
    string Username,
    string Password
);