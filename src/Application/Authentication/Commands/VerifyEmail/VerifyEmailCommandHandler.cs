using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Users;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.VerifyEmail;

public class VerifyEmailCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<VerifyEmailCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(VerifyEmailCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(UserId.Create(command.UserId));

        if (user is null) return Errors.User.NotFound;

        if (user.IsEmailVerified) return Errors.Authentication.EmailAlreadyVerified;

        if (user.EmailVerificationToken != command.Token || user.EmailVerificationTokenExpiry < DateTime.UtcNow) return Errors.Authentication.InvalidToken;

        user.VerifyEmail();
        await userRepository.UpdateAsync(user);

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
