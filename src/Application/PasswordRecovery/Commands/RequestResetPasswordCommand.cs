using ErrorOr;
using MediatR;

namespace Application.PasswordRecovery.Commands;

public record RequestResetPasswordCommand(
    string Username
) : IRequest<ErrorOr<Unit>>;

