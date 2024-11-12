using Domain.Primitives;

namespace Domain.Users.Events;

public record EmailVerificationTokenGeneratedEvent(
    UserId UserId,
    string Email,
    string Username,
    string Token
) : IDomainEvent;