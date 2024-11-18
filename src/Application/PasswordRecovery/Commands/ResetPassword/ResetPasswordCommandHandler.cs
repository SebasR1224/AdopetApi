using Application.Common.Interfaces.Password;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.PasswordRecovery.Commands.ResetPassword;

public sealed class ResetPasswordCommandHandler(
    IPasswordRecoveryTokenRepository
    recoveryTokenRepository,
    IUserRepository userRepository,
    IPasswordHasher passwordHasher) : IRequestHandler<ResetPasswordCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var token = await recoveryTokenRepository.GetByTokenAsync(request.Token);

        if (token is null || !token.IsValid())
            return Errors.PasswordRecovery.InvalidToken;

        var user = await userRepository.GetByUsernameOrEmailAsync(token.Email);

        if (user is null) return Errors.User.NotFound;

        var hashedPassword = passwordHasher.HashPassword(request.NewPassword);
        user.UpdatePassword(hashedPassword);

        token.MarkAsUsed();
        await userRepository.UpdateAsync(user);
        await recoveryTokenRepository.UpdateAsync(token);

        return Unit.Value;
    }
}
