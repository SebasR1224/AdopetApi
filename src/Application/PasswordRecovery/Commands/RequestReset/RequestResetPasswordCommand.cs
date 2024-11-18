using ErrorOr;
using MediatR;

namespace Application.PasswordRecovery.Commands.RequestReset;

public record RequestResetPasswordCommand(
    string Username
) : IRequest<ErrorOr<Unit>>;

