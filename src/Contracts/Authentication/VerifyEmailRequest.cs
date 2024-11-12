namespace Contracts.Authentication;

public record VerifyEmailRequest(Guid UserId, string Token);
