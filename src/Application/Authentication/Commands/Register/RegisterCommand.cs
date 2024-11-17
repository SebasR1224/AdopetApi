using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.Register;

public record RegisterCommand(
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
) : IRequest<ErrorOr<Unit>>;