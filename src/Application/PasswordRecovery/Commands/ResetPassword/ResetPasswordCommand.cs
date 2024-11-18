using ErrorOr;
using MediatR;

namespace Application.PasswordRecovery.Commands.ResetPassword;

public record ResetPasswordCommand(
    string Token,
    string NewPassword
) : IRequest<ErrorOr<Unit>>;